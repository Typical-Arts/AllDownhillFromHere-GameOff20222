using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class StartMenuInteration : MonoBehaviour
{
    [SerializeField] Button _startButton;
    [SerializeField] Button _settingsButton;
    [SerializeField] Button _exitButton;
    [SerializeField] GameObject _settingsPanel;
    [SerializeField] SettingsBehavior _settingsBehavior;

    [Header("Button Animations")]
    [Tooltip("Start Button Flyin Duration")]
    [SerializeField] private float _startFlyInDuration;

    [Tooltip("Settings Button Flyin Duration")]
    [SerializeField] private float _settingsFlyInDuration;

    [Tooltip("Exit Button Flyin Duration")]
    [SerializeField] private float _exitFlyInDuration;


    private TMP_Text _startText;

    private RectTransform _startRectTransform;
    private RectTransform _settingsRectTransform;
    private RectTransform _exitRectTransform;

    void Start()
    {
        _startButton.onClick.AddListener(StartClick);
        _settingsButton.onClick.AddListener(SettingsCick);
        _exitButton.onClick.AddListener(ExitClick);

        _startRectTransform = _startButton.GetComponent<RectTransform>();
        _settingsRectTransform = _settingsButton.GetComponent<RectTransform>();
        _exitRectTransform = _exitButton.GetComponent<RectTransform>();

        _startRectTransform.DOAnchorPos(
            new Vector2(0, _startRectTransform.anchoredPosition.y),
            _startFlyInDuration
        );
        _settingsRectTransform.DOAnchorPos(
            new Vector2(0, _settingsRectTransform.anchoredPosition.y),
            _settingsFlyInDuration
        );
        _exitRectTransform.DOAnchorPos(
            new Vector2(0, _exitRectTransform.anchoredPosition.y),
            _exitFlyInDuration
        );
        _settingsBehavior.OnClose(HandleSettingsClose);
    }

    void StartClick()
    {
        SoundManager.Instance.StopMusic(1f);
        SceneManager.LoadScene(1);
        Debug.Log("start click");
    }

    void SettingsCick()
    {
        _settingsPanel.SetActive(!_settingsPanel.activeInHierarchy);
    }

    void HandleSettingsClose()
    {
        _settingsPanel.SetActive(false);
    }

    void ExitClick()
    {
        Debug.Log("exitting");
        Application.Quit();
    }
}
