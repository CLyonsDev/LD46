using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float Delay;

    private float timer;

    // Start is called before the first frame update
    void OnEnable()
    {
        timer = Delay;
        //StartCoroutine(DelayedDestroy());
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(Delay);
        //Destroy(this.gameObject);

        //if(GetComponent<ExplodeOnCollision>() != false)
        //{
            //GetComponent<ExplodeOnCollision>().ExplodeCar();
        //}
    }
}
