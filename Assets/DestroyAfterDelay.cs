using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float Delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(Delay);
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);

        if(GetComponent<ExplodeOnCollision>() != false)
        {
            GetComponent<ExplodeOnCollision>().ExplodeCar();
        }
    }
}
