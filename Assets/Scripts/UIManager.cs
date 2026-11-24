using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject gameoverUI;

    [Header("Interact Prompt")]
    [SerializeField] private TMP_Text promptText;
    [SerializeField] private string prompt;

    [Header("Interact Message")]
    [SerializeField] float messageDuration = 3.0f;
    [SerializeField] float fadeOutTime = .5f;

    [SerializeField] private TMP_Text messageText;
    private Coroutine messageFadeCoroutine;

    [Header("Dialogue")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    public void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
        pausedUI.SetActive(false);
        settingsUI.SetActive(false);
        gameoverUI.SetActive(false);
    }

    private void Awake()
    {
        DisplayMessage("");
        HidePrompt();

        HideDialoguePanel();
    }

    public void ShowMainMenu()
    {
        HideAllUI();

        mainMenuUI.SetActive(true);
    }

    public void ShowGamePlay()
    {
        HideAllUI();

        gameplayUI.SetActive(true);
    }

    public void ShowPaused()
    {
        HideAllUI();

        gameplayUI.SetActive(true);
        pausedUI.SetActive(true);
    }

    public void ShowSettings()
    {
        HideAllUI();

        settingsUI.SetActive(true);
    }

    public void ShowGameOver()
    {
        HideAllUI();

        gameoverUI.SetActive(true);
    }

    public void ShowPrompt()
    {
        promptText.text = prompt;
        ClearMessage();
    }

    public void HidePrompt()
    {
        promptText.text = "";
    }

    public void ClearMessage()
    {
        if(messageFadeCoroutine != null) StopCoroutine(messageFadeCoroutine);

        messageText.text = "";
    }

    public void ShowDialoguePanel()
    {
        dialoguePanel.SetActive(true);
    }

    public void SetDialogueText(string dialogueString)
    {
        dialogueText.text = dialogueString;
    }

    public void HideDialoguePanel()
    {
        dialoguePanel.SetActive(false);
    }

    public void DisplayMessage(string message)
    {
        if(messageFadeCoroutine != null) StopCoroutine(messageFadeCoroutine);

        messageFadeCoroutine = StartCoroutine(DisplayMessageAndFade(message));
    }

    private IEnumerator DisplayMessageAndFade(string message)
    {
        messageText.text = message;
        messageText.alpha = 1f;

        float elaspedTime = 0f;

        yield return new WaitForSeconds(messageDuration);

        while(elaspedTime < messageDuration)
        {
            elaspedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elaspedTime / fadeOutTime);

            messageText.alpha = alpha;

            yield return null;
        }
        messageText.text = "";
    }
}
