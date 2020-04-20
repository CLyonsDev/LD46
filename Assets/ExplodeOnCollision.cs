using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnCollision : MonoBehaviour
{
    public bool hasExploded = false;
    private bool canExplode = false;

    public AudioClip[] explosionClips;
    private AudioSource source;
    public GameObject ExplosionParticleEffect;

    private float invulnTimer = 0f;
    private float invulnDuration = 1.6f;

    private float despawnTimer = 0;
    private float despawnTimeAfterCollision = 2f;
    private bool earlyDespawn = false;

    private void OnEnable()
    {
        invulnTimer = invulnDuration;
        earlyDespawn = false;
        despawnTimer = despawnTimeAfterCollision;
    }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        invulnTimer -= Time.deltaTime;

        if(invulnTimer <= 0)
        {
            canExplode = true;
        }

        if(earlyDespawn)
        {
            despawnTimer -= Time.deltaTime;
        }

        if(despawnTimer <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((collision.transform.root.CompareTag("AI Car") || collision.transform.root.CompareTag("Player") || collision.transform.root.CompareTag("AI Pedestrian")) && !hasExploded && canExplode)
        {
            ExplodeCar();
            hasExploded = true;
        }
    }

    public void ExplodeCar()
    {
        despawnTimer = despawnTimeAfterCollision;
        earlyDespawn = true;

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
