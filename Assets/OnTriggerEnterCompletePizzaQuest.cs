using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterCompletePizzaQuest : MonoBehaviour
{
    public DeliveryMission LinkedMission;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);

        if (LinkedMission.IsComplete == false && LinkedMission == other.transform.root.GetComponent<QuestManager>().CurrentMission)
        {
            LinkedMission.IsComplete = true;
            Debug.Log("Pizza delivered!");
        }
    }
}
