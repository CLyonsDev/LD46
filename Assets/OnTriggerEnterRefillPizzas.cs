using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterRefillPizzas : MonoBehaviour
{
    public Transform PizzaPoint;

    public GameObject PizzaPrefab;

    private bool spawnedPizza = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!spawnedPizza)
        {
            spawnedPizza = true;
            Instantiate(PizzaPrefab, PizzaPoint.position, PizzaPoint.rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        spawnedPizza = false;
    }
}
