using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationSequence : MonoBehaviour
{
    public NotificationObject[] AllNotificationsInSequence;
    public TooltipManager PopupManager;
    public AudioSource UiAudioSource;

    private float timer = 0.0f;
    private int index = 0;

    void Start()
    {
        
    }

    public void StartNotificationSequence()
    {
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        //Debug.Log("Starting sequence");
        int index = 0;

        while(index <= AllNotificationsInSequence.Length-1)
        {
            /*Debug.Log("Loop");
            NotificationObject current = AllNotificationsInSequence[index];
            PopupManager.SetTooltipInfo(current.NotificationText);
            UiAudioSource.PlayOneShot(current.AccompanyingClip, 0.75f);

            yield return new WaitForSeconds(current.Duration);

            if(current.EventToRaiseUponCompletion != null)
            {
                current.EventToRaiseUponCompletion.Raise();
            }

            PopupManager.HideTooltip();
            index++;*/

            NotificationObject current = AllNotificationsInSequence[index];

            PopupManager.CreateTooltip(current.NotificationText, current.Duration);

            UiAudioSource.PlayOneShot(current.AccompanyingClip, 0.75f);

            yield return new WaitForSeconds(current.Duration);

            if (current.EventToRaiseUponCompletion != null)
            {
                current.EventToRaiseUponCompletion.Raise();
            }

            Debug.Log("Loop");
            index++;
        }
    }
}
