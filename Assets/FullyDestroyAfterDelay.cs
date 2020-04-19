using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullyDestroyAfterDelay : MonoBehaviour
{
    public void DestroyAfterDelay(float delay)
    {
        StartCoroutine(TimedDestruction(delay));
    }

    private IEnumerator TimedDestruction(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
