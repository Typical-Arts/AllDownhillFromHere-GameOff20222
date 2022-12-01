using System.Collections.Generic;
using UnityEngine;

public class GameMusicPlayer : MonoBehaviour
{
    [Tooltip("Tracks")]
    public List<AudioClip> tracks;
    [Tooltip("Shuffle")]
    public bool _shuffle = true;

    private int _currentTrackNumber = 0;

    void Update()
    {
        // If the soundmanager is playing do nothing
        if (SoundManager.Instance.musicIsPlaying) return;
        int nextTrackIndex;

        if (_shuffle) {
           nextTrackIndex = Random.Range(0, tracks.Count);
           if(nextTrackIndex == _currentTrackNumber) {
            return;
           }

           _currentTrackNumber = nextTrackIndex;
           SoundManager.Instance.PlayMusic(tracks[nextTrackIndex], 2f);

        } else {
            nextTrackIndex = _currentTrackNumber++;
            if (nextTrackIndex > tracks.Count) {
                nextTrackIndex = 0;
            }
            SoundManager.Instance.PlayMusic(tracks[nextTrackIndex], 2f); 
        }
    }
}
