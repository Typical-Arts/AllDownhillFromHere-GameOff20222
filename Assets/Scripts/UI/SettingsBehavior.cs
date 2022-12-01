using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SettingsBehavior : MonoBehaviour
{
    [SerializeField] Button _closeButton;
    [SerializeField] ToggleBehavior _soundEffectsToggleBehavior;
    [SerializeField] ToggleBehavior _musicToggleBehavior;
    [SerializeField] SliderBehavior _volumeSliderBehavior;
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] Button _firstSlected;

    void Start()
    {
        SetAllValues();
        if (_eventSystem) {
            _eventSystem.SetSelectedGameObject(_firstSlected.gameObject);
        }

        SoundManager.Instance.update += SetAllValues;
        _soundEffectsToggleBehavior.OnToggle(HandleSoundEffectsToggle);
        _musicToggleBehavior.OnToggle(HandleMusicToggle);
        _volumeSliderBehavior.OnValueChanged(HandleVolumeChanged);
    }

    void OnDestroy() {
        SoundManager.Instance.update -= SetAllValues;    
    }

    public void OnClose(UnityAction action)
    {
        _closeButton.onClick.AddListener(action);
    }

    void SetAllValues()
    {
        _soundEffectsToggleBehavior.SetValue(!SoundManager.Instance.effectsMuted);
        _musicToggleBehavior.SetValue(!SoundManager.Instance.musicMuted);
        _volumeSliderBehavior.SetValue(SoundManager.Instance.mainVolume);
    }

    void HandleSoundEffectsToggle() 
    {
        SoundManager.Instance.effectsMuted = !SoundManager.Instance.effectsMuted;
    }

    void HandleMusicToggle() 
    {
        SoundManager.Instance.musicMuted = !SoundManager.Instance.musicMuted;
    }

    void HandleVolumeChanged(float volume)
    {
        SoundManager.Instance.mainVolume = volume;
    }
}
