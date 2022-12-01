using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource, _effectsSource;

    public UnityAction update;

    public bool musicMuted
    {
        get { return _musicSource.mute; }
        set
        {
            _musicSource.mute = value;
            update.Invoke();
        }
    }

    public bool effectsMuted
    {
        get { return _effectsSource.mute; }
        set
        {
            _effectsSource.mute = value;
            update.Invoke();
        }
    }

    public bool musicIsPlaying
    {
        get { return _musicSource.isPlaying; }
    }

    public float mainVolume
    {
        get { return AudioListener.volume; }
        set
        {
            AudioListener.volume = value;
            update.Invoke();
        }
    }

    public static SoundManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEffect(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void PlayEffectAtPoint(AudioClip clip, Vector3 point)
    {
        AudioSource.PlayClipAtPoint(clip, point, effectsMuted ? 0f : _effectsSource.volume);
    }

    public void PlayMusic(AudioClip clip, float fadeIn = 0)
    {
        if (fadeIn > 0)
        {
            float currentVolume = _musicSource.volume;
            _musicSource.volume = 0f;
            _musicSource.clip = clip;
            _musicSource.Play();
            _musicSource.DOFade(currentVolume, fadeIn);
        }
        else
        {
            _musicSource.PlayOneShot(clip);
        }
    }

    public void SetMusicLoop(bool value)
    {
        _musicSource.loop = value;
    }

    public void StopMusic(float fadeOut = 0)
    {
        if (fadeOut > 0)
        {
            float currentVolume = _musicSource.volume;
            _musicSource.DOFade(0f, fadeOut).OnComplete(() =>
            {
                _musicSource.Stop();
                _musicSource.volume = currentVolume;
            });
        }
        else
        {
            _musicSource.Stop();
        }
    }
}
