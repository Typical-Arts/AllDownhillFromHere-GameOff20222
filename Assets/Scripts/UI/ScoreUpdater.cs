using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdater : MonoBehaviour
{
    [SerializeField] private ScoreManagment _scoreManager;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _slider;

    void Start()
    {
        _slider.maxValue = _scoreManager.pointsToWin;
        _scoreManager.onWin += () => this.gameObject.SetActive(false);
    }

    void Update()
    {
        int score = _scoreManager.score;
        _text.text = string.Format("{0} of {1}", score.ToString(), _scoreManager.pointsToWin);
        if (score > 0)
        {
            _slider.value = score;
        }
    }
}
