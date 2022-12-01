using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class HouseHurt : MonoBehaviour, IhurtBox
{
    public int points { get => _points; set => _points = value; }

    [Tooltip("Points")] 
    [SerializeField]
    private int _points;

    [Tooltip("Destriction Sounds")]
    public List<AudioClip> destructionClips;

    [Tooltip("Easter Egg")]
    public AudioClip easterEggClip;

    private RayfireRigid _rayFireRigid;

    public void OnHurt()
    {
        _points = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rayFireRigid = GetComponent<RayfireRigid>();
        _rayFireRigid.demolitionEvent.LocalEvent += PlayDemolishSound;
    }

    void PlayDemolishSound(RayfireRigid rigid)
    {
        int clipIndex = Random.Range(0, destructionClips.Count);
        SoundManager.Instance.PlayEffectAtPoint(destructionClips[clipIndex], rigid.limitations.contactVector3);
        SoundManager.Instance.PlayEffect(easterEggClip);
    }
}
