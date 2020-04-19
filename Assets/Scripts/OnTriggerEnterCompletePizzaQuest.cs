using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterCompletePizzaQuest : MonoBehaviour
{
    public DeliveryMission LinkedMission;
    private bool hasPlayedEnterClip = false;
    public AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);

        if (LinkedMission.IsComplete == false && other.transform.root.CompareTag("Player"))
        {
            if(LinkedMission == other.GetComponentInParent<QuestManager>().CurrentMission)
            {
                //LinkedMission.IsComplete = true;
                //Debug.Log("Pizza delivered!");
                //DirectionMarkerDestination.Value = LinkedMission.ReturnLocation;
                //other.GetComponentInParent<QuestManager>().SpawnMarkerAtVec3(LinkedMission.ReturnLocation);
                LinkedMission.IsInDeliveryZone = true;
                Debug.Log("Is in delivery zone!");

                if(hasPlayedEnterClip == false)
                {
                    source.PlayOneShot(LinkedMission.InZoneClip, 0.5f);
                    hasPlayedEnterClip = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(LinkedMission.IsInDeliveryZone == true && other.transform.root.CompareTag("Player"))
        {
            if(other.GetComponentInParent<QuestManager>().CurrentMission == LinkedMission)
            {
                LinkedMission.IsInDeliveryZone = false;
                Debug.Log("Left delivery zone!");
            }
        }
    }
}
