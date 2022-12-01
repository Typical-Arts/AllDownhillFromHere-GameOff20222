using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] private Canvas _pauseMenu;
    [SerializeField] private SettingsBehavior _settingsBehavior;
    [SerializeField] private FailMenuBehavior _failMenuBehavior;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Timer _gameTimer;

    private PlayerInputActions _inputActions;
    private InputAction _pause;
    private bool isPaused = false;

    void Awake()
    {
        _inputActions = new PlayerInputActions();
    }

    void Start() {
        _pause = _inputActions.Player.Pause;
        _pause.Enable();
        _pause.started += HandlePause;
        _settingsBehavior.OnClose(HandlePause);
        _exitButton.onClick.AddListener(HandleExit);
        _gameTimer.timeExpired += HandleTimeExpired;
    }

    void HandlePause(InputAction.CallbackContext context)
    {
        HandlePause();
    }

    void HandlePause()
    {
        if (isPaused)
        {
            _pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 1;
        } else
        {
            _pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        isPaused = !isPaused;
    }

    void HandleExit()
    {
        Debug.Log("Quitting the game"); 
        Application.Quit();
    }

    void HandleTimeExpired()
    {
        Time.timeScale = 0;
        _failMenuBehavior.gameObject.SetActive(true);
    }
}
