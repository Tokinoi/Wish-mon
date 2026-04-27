using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] private Button _firstButton;    

    private void Start()
    {
    EventSystem.current.SetSelectedGameObject(_firstButton.gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("World");
    }

    public void LeaveGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }

}
