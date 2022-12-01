using UnityEngine;

public class CubeHurt : MonoBehaviour, IhurtBox
{
    public int points { get => _points; set => _points = value; }
    [Tooltip("Points")]
    [SerializeField]
    private int _points;


    public void OnHurt()
    {
        Debug.Log("Cube Strike");
        enabled = false;
    }
}
