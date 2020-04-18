using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pizza Quest", menuName = "Missions/New Pizza Quest")]
public class DeliveryMission : ScriptableObject
{
    public bool IsInDeliveryZone = false;
    public bool IsComplete = false;
    public bool InitialValue = false;

    public Vector3 ObjectiveMarkerLocation;
    public Vector3 ReturnLocation;

    public void Init()
    {
        IsComplete = InitialValue;
        IsInDeliveryZone = InitialValue;
    }

    public void CompleteQuest()
    {
        IsComplete = true;
    }
}
