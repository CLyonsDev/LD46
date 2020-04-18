using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAICar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<AICar>())
        {
            other.transform.root.gameObject.SetActive(false);
        }
    }
}
