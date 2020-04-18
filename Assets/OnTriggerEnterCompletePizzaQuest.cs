using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterCompletePizzaQuest : MonoBehaviour
{
    public DeliveryMission LinkedMission;
    public Vector3Reference DirectionMarkerDestination;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);

        if (LinkedMission.IsComplete == false && LinkedMission == other.GetComponentInParent<QuestManager>().CurrentMission)
        {
            LinkedMission.IsComplete = true;
            Debug.Log("Pizza delivered!");
            DirectionMarkerDestination.Value = LinkedMission.ReturnLocation;
        }
    }
}
