using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianPooler : MonoBehaviour
{
    public static PedestrianPooler Instance;

    public List<GameObject> PooledPedestrians = new List<GameObject>();
    public GameObject PedestrianPrefab;
    public int maxPedestrians;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < maxPedestrians; i++)
        {
            GameObject ai = (GameObject)Instantiate(PedestrianPrefab);
            ai.SetActive(false);
            PooledPedestrians.Add(ai);
        }
    }

    public GameObject GetAvailablePedestrian()
    {
        for (int i = 0; i < PooledPedestrians.Count; i++)
        {
            if (PooledPedestrians[i].activeInHierarchy == false)
            {
                return PooledPedestrians[i];
            }
        }
        return null;
    }
}
