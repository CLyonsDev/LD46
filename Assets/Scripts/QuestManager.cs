using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<DeliveryMission> AllMissions = new List<DeliveryMission>();

    public DeliveryMission CurrentMission;

    public Vector3Reference MarkerReference;

    public GameObject ParticleMarkerPrefab;
    private GameObject activeMarker;

    public NotificationSequence sequenceManager;

    private void Start()
    {
        foreach (DeliveryMission mission in AllMissions)
        {
            mission.Init();
        }

        CurrentMission = AllMissions[0];

        MarkerReference.Value = CurrentMission.ObjectiveMarkerLocation;
        SpawnMarkerAtVec3(CurrentMission.ObjectiveMarkerLocation);

        sequenceManager.AllNotificationsInSequence = CurrentMission.Notifications;
        sequenceManager.StartNotificationSequence();
    }

    public void NextMission()
    {
        CurrentMission = AllMissions[AllMissions.IndexOf(CurrentMission) + 1];
        MarkerReference.Value = CurrentMission.ObjectiveMarkerLocation;
        SpawnMarkerAtVec3(CurrentMission.ObjectiveMarkerLocation);

        sequenceManager.AllNotificationsInSequence = CurrentMission.Notifications;
        sequenceManager.StartNotificationSequence();
    }

    public void SpawnMarkerAtVec3(Vector3 pos)
    {
        if(activeMarker != null)
        {
            Destroy(activeMarker.gameObject);
        }

        //activeMarker = (GameObject)Instantiate(ParticleMarkerPrefab, CurrentMission.ObjectiveMarkerLocation, Quaternion.identity);
    }
}
