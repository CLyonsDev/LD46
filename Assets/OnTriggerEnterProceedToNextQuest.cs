using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterProceedToNextQuest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.transform.root.GetComponent<QuestManager>().CurrentMission.IsComplete)
        {
            other.GetComponentInParent<QuestManager>().NextMission();
            Debug.Log("Good job! Next delivery.");
        }
    }
}
