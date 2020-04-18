using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<DeliveryMission> AllMissions = new List<DeliveryMission>();

    public DeliveryMission CurrentMission;

    public Vector3Reference MarkerReference;

    private void Start()
    {
        foreach (DeliveryMission mission in AllMissions)
        {
            mission.Init();
        }

        CurrentMission = AllMissions[0];

        MarkerReference.Value = CurrentMission.ObjectiveMarkerLocation;
    }

    public void NextMission()
    {
        CurrentMission = AllMissions[AllMissions.IndexOf(CurrentMission) + 1];
        MarkerReference.Value = CurrentMission.ObjectiveMarkerLocation;
    }
}
