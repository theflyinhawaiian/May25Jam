using UnityEngine;

public class ExplodableBehavior : MonoBehaviour, IIgnitable
{
    public void Ignite()
    {
        Debug.Log("ExplodeyBoi has been ignited!");
    }
}
