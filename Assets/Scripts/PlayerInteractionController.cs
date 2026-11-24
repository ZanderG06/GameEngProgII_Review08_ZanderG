using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    private IInteractable targetInteractable;

    [SerializeField] private GameObject debugCurrentInteractable;

    private UIManager uiManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = ServiceHub.Instance.UIManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable = foundInteractable;
            debugCurrentInteractable = collision.gameObject;

            uiManager.ShowPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable foundInteractable))
        {
            targetInteractable = null;
            debugCurrentInteractable = null;

            uiManager.HidePrompt();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed && targetInteractable != null)
        {
            uiManager.HidePrompt();

            targetInteractable.Interact();
        }
    }
}
