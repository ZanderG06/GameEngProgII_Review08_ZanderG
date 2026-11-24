using UnityEngine;

public class Interactable_Dialogue : MonoBehaviour, IInteractable
{
    private DialogueManager dialogueManager;
    private QuestManager questManager;

    [Header("Dialogue Text")]
    private string[] sentences;

    private void Start()
    {
        dialogueManager = ServiceHub.Instance.DialogueManager;
        questManager = ServiceHub.Instance.QuestManager;
    }

    public void Interact()
    {
        if (dialogueManager.inDialogue) dialogueManager.DisplayNextString();
        else
        {
            sentences = questManager.UpdateSentence(gameObject);
            dialogueManager.StartDialogue(sentences);
        }
        questManager.UpdateQuest(gameObject);
    }
}
