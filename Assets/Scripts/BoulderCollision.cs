using UnityEngine;

public class BoulderCollision : MonoBehaviour
{
    [Tooltip("Score Layers")]
    public LayerMask scoreLayers;
    
    [Tooltip("Score Manager")]
    public ScoreManagment _scoreManager;

    void OnTriggerEnter(Collider other)
    {
        // if the collisions layer is in the score layermask
        if ((scoreLayers.value & 1 << other.gameObject.layer) > 0)
        {
            IhurtBox hurtBox = other.GetComponent<IhurtBox>();
            if (hurtBox != null)
            {
                _scoreManager.addPoints(hurtBox.points);
                hurtBox.OnHurt();
            }
        }
    }
}
