using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAICar : MonoBehaviour
{
    public float MinSpeed = 150;
    public float MaxSpeed = 200;

    public float MinSpawnDelay;
    public float MaxSpawnDelay;

    public GameObject[] AICarPrefabs;
    public Transform[] SpawnLocations;

    private int minSpawnedPerCycle = 1;
    private int maxSpawnedPerCycle = 1;
    private float minCycleSpawnDelay = 0.1f;
    private float maxCycleSpawnDelay = 0.35f;

    private float timer = 0f;
    private float spawnDelay = 0f;

    void Start()
    {
        //StartCoroutine(SpawnCarsInterval());
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnDelay)
        {
            SpawnCars();
        }
    }

    private void SpawnCars()
    {
        timer = 0f;
        spawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);

        for (int i = 0; i < SpawnLocations.Length; i++)
        {
            GameObject AiCar = AICarPooler.Instance.GetAvailableAiCar();

            if (AiCar != null)
            {
                Vector3 spawnPos = SpawnLocations[i].position;
                Quaternion spawnRot = SpawnLocations[i].rotation;

                Rigidbody rb = AiCar.GetComponent<Rigidbody>();

                rb.velocity = Vector3.zero;

                AiCar.SetActive(true);

                rb.transform.position = spawnPos;
                rb.transform.rotation = spawnRot;

                AiCar.GetComponent<AICar>().speed = Random.Range(MinSpeed, MaxSpeed);
                AiCar.GetComponent<RandomizeCarPaintColor>().RandomizePaintColor();
                AiCar.GetComponent<AICar>().ActivateAI();
                AiCar.GetComponent<ExplodeOnCollision>().hasExploded = false;
            }
        }
    }

    private IEnumerator SpawnCarsInterval()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnDelay, MaxSpawnDelay));
            //GameObject AICar = Instantiate(AICarPrefabs[Random.Range(0, AICarPrefabs.Length)], transform.position, transform.rotation);
            //AICar.GetComponent<AICar>().speed = Random.Range(MinSpeed, MaxSpeed);

            for (int i = 0; i < SpawnLocations.Length; i++)
            {
                GameObject AiCar = AICarPooler.Instance.GetAvailableAiCar();

                if (AiCar != null)
                {
                    Vector3 spawnPos = SpawnLocations[i].position;
                    Quaternion spawnRot = SpawnLocations[i].rotation;

                    Rigidbody rb = AiCar.GetComponent<Rigidbody>();

                    rb.velocity = Vector3.zero;

                    AiCar.SetActive(true);

                    rb.MovePosition(spawnPos);
                    rb.MoveRotation(spawnRot);

                    AiCar.GetComponent<AICar>().speed = Random.Range(MinSpeed, MaxSpeed);
                    AiCar.GetComponent<RandomizeCarPaintColor>().RandomizePaintColor();
                    AiCar.GetComponent<AICar>().ActivateAI();
                    AiCar.GetComponent<ExplodeOnCollision>().hasExploded = false;
                }
            }
        }
    }
}
