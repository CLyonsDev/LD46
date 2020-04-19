using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullyDestroyAfterDelay : MonoBehaviour
{
    private float timer;

    public void DestroyAfterDelay(float delay)
    {
        //StartCoroutine(TimedDestruction(delay));
        timer = delay;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator TimedDestruction(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
