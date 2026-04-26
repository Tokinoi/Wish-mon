using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Canvas _pauseMenuCanvas;
    [SerializeField] private InputActionReference _pauseRef;

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
    }

}
