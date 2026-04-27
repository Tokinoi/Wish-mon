using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas _pauseMenuCanvas;
    [SerializeField] private InputActionReference _pauseRef;
    [SerializeField] private Button _firstButton;    
    public void Start()
    {
        _pauseMenuCanvas.enabled = false;
        TogglePauseMenu(false);
    }

    public void Update()
    {
        if (_pauseRef.action.WasPressedThisFrame()){
            TogglePauseMenu(!_pauseMenuCanvas.enabled);
        }
    }

    public void TogglePauseMenu(bool isPaused)
    {
        Time.timeScale = isPaused ? 0 : 1;
        _pauseMenuCanvas.enabled = isPaused;
        Debug.Log(EventSystem.current);
        if (isPaused)
            EventSystem.current.SetSelectedGameObject(_firstButton.gameObject);
        else
            EventSystem.current.SetSelectedGameObject(null);
    }

    public void SaveAndQuit()
    {
        Debug.Log("Game Saved! Quitting...");
        SceneManager.LoadScene("MainMenu");
    }

    public void Bag()
    {
        Debug.Log("Opening Bag...");
    }

    public void WishemonPedia()
    {
        Debug.Log("Opening WishemonPedia...");
    }

    public void Teams()
    {
        Debug.Log("Opening Teams...");
    }

}
