using UnityEngine;
using UnityEngine.Events;

public class ScoreManagment : MonoBehaviour
{
    [Header("Score")]
    [Tooltip("Current Score")]
    public int score;
    [Tooltip("Points Needed To Win")]
    public int pointsToWin;
    public UnityAction onWin;
    public void addPoints(int points)
    {
        score += points;
        if (score >= pointsToWin) {
            SoundManager.Instance.StopMusic(0);
            Time.timeScale = 0;
            onWin.Invoke();
        }
    }
}
