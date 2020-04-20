using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterRaiseGameEvent : MonoBehaviour
{
    public GameEvent Gevent;
    public QuestManager manager;
    public DeliveryMission mission;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.CompareTag("Player") && manager.CurrentMission == mission)
        {
            Gevent.Raise();
        }
    }
}
