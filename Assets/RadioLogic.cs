using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioLogic : MonoBehaviour
{
    public AudioClip[] RadioClips;

    private AudioSource source;

    private int index = 0;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!source.isPlaying)
        {
            source.clip = RadioClips[index];
            source.Play();

            if(index + 1 < RadioClips.Length)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
    }
}
