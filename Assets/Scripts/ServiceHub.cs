using System.Runtime.CompilerServices;
using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("System References")]
    [SerializeField] private GameStateManager gameStateManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private PlayerController playerMovementController;
    [SerializeField] private PlayerInteractionController playerInteractionController;
    [SerializeField] private GameObject player;

    public GameStateManager GameStateManager => gameStateManager;
    public UIManager UIManager => uiManager;
    public LevelManager LevelManager => levelManager;
    public DialogueManager DialogueManager => dialogueManager;
    public QuestManager QuestManager => questManager;
    public PlayerController PlayerMovementController => playerMovementController;
    public PlayerInteractionController PlayerInteractionController => playerInteractionController;
    public GameObject Player => player;

    private void Awake()
    {
        #region Singleton Pattern

        // Simple singleton setup for a single-scene game
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        #endregion
    }
}
