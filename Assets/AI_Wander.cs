using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Wander : MonoBehaviour
{
    private NavMeshAgent agent;

    private float radius = 100;
    private Vector3 target;

    public LayerMask mask;

    private float timeout = 25f;
    private float timer;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        CalculateNewDestination();
    }

    private void Update()
    {
        if (agent.enabled == false)
            return;

        timer += Time.deltaTime;

        if(timer >= timeout)
        {
            CalculateNewDestination();
        }

        if(Vector3.Distance(transform.position, agent.pathEndPosition) <= 1f)
        {
            CalculateNewDestination();
        }
    }

    private void CalculateNewDestination()
    {
        if (agent.enabled == false)
            return;

        timer = 0;

        Vector3 randPos = Random.insideUnitSphere * radius;
        NavMeshHit hit;
        NavMesh.SamplePosition(randPos, out hit, radius, mask);
        target = hit.position;
        agent.destination = target;
    }
}
