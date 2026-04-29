using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public void DisplayMessage(string message)
    {
        _dialoguePanel.SetActive(true);
        _dialogueText.text = message;
    }

    public void Hide()
    {
        _dialoguePanel.SetActive(false);
    }

}