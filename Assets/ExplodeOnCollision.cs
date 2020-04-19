using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    private bool hasExploded = false;

    public AudioClip[] explosionClips;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((collision.transform.root.CompareTag("AI Car") || collision.transform.root.CompareTag("Player")) && !hasExploded)
        {
            ExplodeCar();
            hasExploded = true;
        }
    }

    private void ExplodeCar()
    {
        source.pitch = Random.Range(0.65f, 1f);
        source.PlayOneShot(explosionClips[Random.Range(0, explosionClips.Length)], 0.25f);
        GetComponent<AICar>().DeactivateAI();
    }
}
