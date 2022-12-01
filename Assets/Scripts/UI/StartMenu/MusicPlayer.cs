using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    void Start()
    {
        SoundManager.Instance.SetMusicLoop(true);
        SoundManager.Instance.PlayMusic(_clip, 3f);
    }

    void OnDestroy()
    {
        SoundManager.Instance.SetMusicLoop(false);
    }
}
