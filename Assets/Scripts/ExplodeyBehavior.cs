using System.Collections;
using UnityEngine;

public class ExplodableBehavior : MonoBehaviour, IIgnitable
{

    private int fuseDuration = 3;
    public int countdownTimer;

    public void Ignite()
    {
        StartCoroutine(Countdown(fuseDuration));
    }

    IEnumerator Countdown(int seconds)
    {
        for (var i = 0; i < seconds; i++)
        {
            Debug.Log($"Fuse burning... {seconds - i} seconds left.");
            countdownTimer = seconds - i;
            yield return new WaitForSeconds(1f);
        }

        Explode();
    }

    public void Explode()
    {
     
        var affectedObjs = Physics2D.OverlapCircleAll(gameObject.transform.position, 3f);

        for (var i = 0; i < affectedObjs.Length; i++)
        {
            if (affectedObjs[i].gameObject.GetComponent<IManipulatable>() != null)
            {
                var explodedObj = affectedObjs[i].gameObject.GetComponent<IManipulatable>();
                explodedObj.OnExplosion(affectedObjs[i].transform.position - gameObject.transform.position, 150f);
            }
            
        }
        Destroy(gameObject);
    }

}
