using UnityEngine;
using System.Collections.Generic;
public class TreeHurt : MonoBehaviour, IhurtBox
{
    [Tooltip("Points")] 
    [SerializeField]
    private int _points;
    [Tooltip("Destriction Sounds")]
    public List<AudioClip> destructionClips;

    public int points { get => _points; set => _points = value; }
    
    public void OnHurt()
    {
        int clipIndex = Random.Range(0, destructionClips.Count);
        SoundManager.Instance.PlayEffectAtPoint(destructionClips[clipIndex], transform.position);
        _points = 0;
    }
}
