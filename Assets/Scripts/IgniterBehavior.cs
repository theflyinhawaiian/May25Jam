using UnityEngine;

public class IgniterBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IIgnitable>() != null)
        {
            var ignitable = collision.gameObject.GetComponent<IIgnitable>();
            ignitable.Ignite();
        }
        
    }
}
