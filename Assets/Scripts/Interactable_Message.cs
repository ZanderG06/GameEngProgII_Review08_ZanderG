using UnityEngine;

public class Interactable_Message : MonoBehaviour, IInteractable
{
    [Header("Message")]
    [SerializeField] private string message;

    private UIManager uiManager;
    private QuestManager questManager;

    private void Start()
    {
        uiManager = ServiceHub.Instance.UIManager;
        questManager = ServiceHub.Instance.QuestManager;
    }

    public void Interact()
    {
        uiManager.DisplayMessage(message);
        questManager.UpdateReadSigns(gameObject);
    }
}
