using UnityEngine;

public class SmallBarrelBehavior : MonoBehaviour, IManipulatable
{
    public void OnExplosion(Vector2 distance, float explosionForce)
    {
        Debug.Log(explosionForce);
        var RB = GetComponent<Rigidbody2D>();
        RB.AddForce(distance.normalized * explosionForce * -1);
    }

}