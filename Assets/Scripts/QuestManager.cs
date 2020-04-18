using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<DeliveryMission> AllMissions = new List<DeliveryMission>();

    public DeliveryMission CurrentMission;

    private void Start()
    {
        foreach (DeliveryMission mission in AllMissions)
        {
            mission.Init();
        }
    }

    public void NextMission()
    {
        CurrentMission = AllMissions[AllMissions.IndexOf(CurrentMission) + 1];
    }
}
