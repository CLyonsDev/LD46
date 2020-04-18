using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarPooler : MonoBehaviour
{
    public static AICarPooler Instance;

    public List<GameObject> PooledCars = new List<GameObject>();
    public GameObject aiCarPrefab;
    public int maxAiCars;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < maxAiCars; i++)
        {
            GameObject ai = (GameObject)Instantiate(aiCarPrefab);
            ai.SetActive(false);
            PooledCars.Add(ai);
        }
    }

    public GameObject GetAvailableAiCar()
    {
        for (int i = 0; i < PooledCars.Count; i++)
        {
            if(PooledCars[i].activeInHierarchy == false)
            {
                return PooledCars[i];
            }
        }

        return null;
    }
}
