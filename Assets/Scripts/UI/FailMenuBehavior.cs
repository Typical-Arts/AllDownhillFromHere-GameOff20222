using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FailMenuBehavior : MonoBehaviour
{
    [SerializeField] private Button _playAgainButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private EventSystem _eventSystem;

    void Start()
    {
        _eventSystem.SetSelectedGameObject(_playAgainButton.gameObject);
        _playAgainButton.onClick.AddListener(PlayAgain);
        _exitButton.onClick.AddListener(ExitGame);
    }

    void PlayAgain()
    {
        Time.timeScale = 1;
        SoundManager.Instance.StopMusic(1f);
        SceneManager.LoadScene(1);
    }

    void ExitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
