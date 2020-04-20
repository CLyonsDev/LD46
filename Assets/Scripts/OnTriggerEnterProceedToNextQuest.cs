using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterProceedToNextQuest : MonoBehaviour
{
    public AudioClip CompleteClip;
    public AudioSource PlayerSource;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.name);
        if(other.transform.root.GetComponent<QuestManager>() != null)
        {
            if (other.transform.root.GetComponent<QuestManager>().CurrentMission.IsComplete)
            {
                other.GetComponentInParent<QuestManager>().NextMission();
                Debug.Log("Good job! Next delivery.");
                PlayerSource.PlayOneShot(CompleteClip, 0.5f);
            }
        }
    }
}
