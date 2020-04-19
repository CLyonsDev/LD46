using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Notification Object", menuName = "Notifications/Notification Object")]
public class NotificationObject : ScriptableObject
{
    public string NotificationText;
    public AudioClip AccompanyingClip;
    public float Duration;

    public GameEvent EventToRaiseUponCompletion;
}
