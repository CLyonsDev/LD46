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
                Rigidbody rb = AiCar.GetComponent<Rigidbody>();
                AiCar.SetActive(true);
                rb.velocity = Vector3.zero;
                rb.MovePosition(this.transform.position);
                rb.MoveRotation(this.transform.rotation);
                //AiCar.transform.position = this.transform.position;
                //AiCar.transform.rotation = this.transform.rotation;
                AiCar.GetComponent<AICar>().speed = Random.Range(MinSpeed, MaxSpeed);
            }
        }
    }
}
