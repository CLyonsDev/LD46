using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    public bool hasExploded = false;

    public AudioClip[] explosionClips;
    private AudioSource source;
    public GameObject ExplosionParticleEffect;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((collision.transform.root.CompareTag("AI Car") || collision.transform.root.CompareTag("Player") || collision.transform.root.CompareTag("AI Pedestrian")) && !hasExploded)
        {
            ExplodeCar();
            hasExploded = true;
        }
    }

    public void ExplodeCar()
    {
        source.pitch = Random.Range(0.65f, 1f);
        source.PlayOneShot(explosionClips[Random.Range(0, explosionClips.Length)], 0.015f);
        GetComponent<AICar>().DeactivateAI();
        Instantiate(ExplosionParticleEffect, transform.position, Quaternion.identity);

        Color32 black = new Color32(0, 0, 0, 255);
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = black;
        }
    }
}
