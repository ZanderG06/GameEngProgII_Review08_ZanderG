using UnityEngine;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    private UIManager uiManager;
    private PlayerController playerMovement;
    private PlayerInteractionController playerInteraction;

    private Queue<string> dialogueQueue;

    public bool inDialogue = false;

    private void Awake()
    {
        uiManager = ServiceHub.Instance.UIManager;
        playerMovement = ServiceHub.Instance.PlayerMovementController;
        playerInteraction = ServiceHub.Instance.PlayerInteractionController;

        dialogueQueue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences)
    {
        uiManager.ShowDialoguePanel();
        inDialogue = true;
        playerMovement.moveEnabled = false;

        foreach(string currentString in sentences) dialogueQueue.Enqueue(currentString);

        DisplayNextString();
    }

    public void DisplayNextString()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        else if (dialogueQueue.Count > 0) uiManager.SetDialogueText(dialogueQueue.Dequeue());
    }

    public void EndDialogue()
    {
        dialogueQueue.Clear();

        uiManager.HideDialoguePanel();

        inDialogue = false;
        playerMovement.moveEnabled = true;
    }
}
