using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPedestrian : MonoBehaviour
{
    private float timer = 0f;
    private float spawnDelay = 0f;

    public float MinSpawnDelay = 3;
    public float MaxSpawnDelay = 5;

    public GameObject[] PedestrianPrefabs;
    public Transform[] SpawnLocations;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnDelay)
        {
            SpawnPedestrians();
        }
    }

    private void SpawnPedestrians()
    {
        timer = 0f;
        spawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);

        for (int i = 0; i < SpawnLocations.Length; i++)
        {
            GameObject Pedestrian = PedestrianPooler.Instance.GetAvailablePedestrian();

            if (Pedestrian != null)
            {
                Vector3 spawnPos = SpawnLocations[i].position;
                Quaternion spawnRot = SpawnLocations[i].rotation;

                Rigidbody rb = Pedestrian.GetComponent<Rigidbody>();

                rb.velocity = Vector3.zero;

                Pedestrian.transform.position = spawnPos;
                Pedestrian.transform.rotation = spawnRot;

                Pedestrian.SetActive(true);
            }
        }
    }
}
