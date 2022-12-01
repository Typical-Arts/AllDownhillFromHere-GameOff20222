using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{

    [Header("Timer Settings")]
    [Tooltip("Level Duration (Seconds)")]
    public float _currentTime;

    public UnityAction timeExpired;

    private TMP_Text _timerText;

    private float _elapesedTime = 0;

    public float ElapsedTime {get => _elapesedTime;}

    void Start()
    {
        _timerText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (_currentTime <= 0)
        {
            timeExpired.Invoke();
            this.gameObject.SetActive(false);
            return;
        }

        _currentTime = _currentTime - Time.deltaTime;
        _elapesedTime = _elapesedTime += Time.deltaTime;
        
        float minutesleft = Mathf.Floor(_currentTime / 60);
        float secondsLeft = Mathf.Floor(_currentTime % 60);

        _timerText.text = string.Format("{0}:{1}", minutesleft.ToString("0"), secondsLeft.ToString("00"));
    }
}
