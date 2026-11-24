using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public GameObject text;
    private Vector2 moveInput;
    private Rigidbody2D playerRB;

    private Animator playerAnimController;
    private int MoveInputXHash = Animator.StringToHash("MoveInputX");
    private int MoveInputYHash = Animator.StringToHash("MoveInputY");
    private int IsMovingHash = Animator.StringToHash("IsMoving");
    private int IsInteractingHash = Animator.StringToHash("IsInteracting");
    private int LastMoveXHash = Animator.StringToHash("LastMoveX");
    private int LastMoveYHash = Animator.StringToHash("LastMoveY");

    public bool moveEnabled = true;

    public void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();

        playerAnimController = GetComponentInChildren<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void HandlePlayerMovement()
    {
        if(!moveEnabled) return;

        playerRB.MovePosition(playerRB.position + moveInput * moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started) playerAnimController.SetBool(IsInteractingHash, true);
        if (context.canceled) playerAnimController.SetBool(IsInteractingHash, false);
    }

    private void Update()
    {
        HandlePlayerAnimations();
    }

    private void HandlePlayerAnimations()
    {
        if (!moveEnabled)
        {
            playerAnimController.SetBool(IsMovingHash, false);
            return;
        }
        
        if (moveInput != Vector2.zero)
        {
            playerAnimController.SetFloat(MoveInputXHash, moveInput.x);
            playerAnimController.SetFloat(MoveInputYHash, moveInput.y);

            playerAnimController.SetBool(IsMovingHash, true);

            if (moveInput.x != 0 || moveInput.y != 0)
            {
                playerAnimController.SetFloat(LastMoveXHash, moveInput.x);
                playerAnimController.SetFloat(LastMoveYHash, moveInput.y);
            }
        }
        else playerAnimController.SetBool(IsMovingHash, false);
    }
}
