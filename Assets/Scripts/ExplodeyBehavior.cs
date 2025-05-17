using UnityEngine;

public class ExplodableBehavior : MonoBehaviour, IIgnitable
{
    public void Ignite()
    {
        Debug.Log("ExplodeyBoi is lit!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
