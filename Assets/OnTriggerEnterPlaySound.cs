using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterPlaySound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip SoundEffect;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.root.tag);
        if(other.transform.root.CompareTag("Player") && !hasPlayed)
        {
            Debug.Log("Play");
            source.PlayOneShot(SoundEffect, 0.5f);
            hasPlayed = true;
        }
    }
}
