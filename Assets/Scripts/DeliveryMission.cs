using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pizza Quest", menuName = "Missions/New Pizza Quest")]
public class DeliveryMission : ScriptableObject
{
    public bool IsComplete = false;
    public bool InitialValue = false;

    public void Init()
    {
        IsComplete = InitialValue;
    }
}
