using UnityEngine;

public class Interactable_Pickup : MonoBehaviour, IInteractable
{
    private QuestManager questManager;

    private void Start()
    {
        questManager = ServiceHub.Instance.QuestManager;
    }

    public void Interact()
    {
        questManager.UpdatePickups(gameObject);
        Destroy(gameObject);
    }
}
