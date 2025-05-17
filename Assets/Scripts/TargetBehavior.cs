using UnityEngine;

public class TargetBehavior : MonoBehaviour, IManipulatable
{
    public void OnExplosion(Vector2 distance, float explosionForce)
    {
        Destroy(gameObject);
    }

}
