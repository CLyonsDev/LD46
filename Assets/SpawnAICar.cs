using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAICar : MonoBehaviour
{
    private float MinSpeed = 15;
    private float MaxSpeed = 25;

    public float MinSpawnDelay;
    public float MaxSpawnDelay;

    public GameObject[] AICarPrefabs;

    void Start()
    {
        StartCoroutine(SpawnCarsInterval());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnCarsInterval()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnDelay, MaxSpawnDelay));
            //GameObject AICar = Instantiate(AICarPrefabs[Random.Range(0, AICarPrefabs.Length)], transform.position, transform.rotation);
            //AICar.GetComponent<AICar>().speed = Random.Range(MinSpeed, MaxSpeed);
            GameObject AiCar = AICarPooler.Instance.GetAvailableAiCar();
            if(AiCar != null)
            {
                AiCar.transform.position = this.transform.position;
                AiCar.transform.rotation = this.transform.rotation;
                AiCar.SetActive(true);
            }
        }
    }
}
