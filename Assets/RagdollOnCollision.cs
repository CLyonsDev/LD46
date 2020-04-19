using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollOnCollision : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject[] ObjectsToToggle;

    private bool isDead = false;

    private float timer = 0f;
    private float timeToRemoveAfterDeath = 5;

    private AudioSource source;

    public AudioClip[] DeathScreams;

    public Animator anim;

    private Rigidbody[] bodies;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        source = GetComponentInChildren<AudioSource>();
        bodies = GetComponentsInChildren<Rigidbody>();
    }

    private void OnEnable()
    {
        //ToggleRagdoll(true);
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }else if(Input.GetKeyDown(KeyCode.T))
        {
            Respawn();
        }*/

        if(isDead)
        {
            timer += Time.deltaTime;

            if(timer >= timeToRemoveAfterDeath)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void ToggleRagdoll(bool isAnimating)
    {
        //anim.enabled = isAnimating;

        anim.enabled = isAnimating;

        foreach (GameObject go in ObjectsToToggle)
        {
            go.SetActive(isAnimating);
        }
    }

    private void Die()
    {
        if (!isDead)
        {
            isDead = true;
            agent.enabled = false;
            ToggleRagdoll(false);
            PlayDeathScream();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit!!!");
        Die();
        foreach (Rigidbody rb in bodies)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
        }
    }

    private void PlayDeathScream()
    {
        source.PlayOneShot(DeathScreams[Random.Range(0, DeathScreams.Length)], 0.12f);
    }

    public void Respawn()
    {
        timer = 0;
        isDead = false;
        agent.enabled = true;
        ToggleRagdoll(true);
    }
}
