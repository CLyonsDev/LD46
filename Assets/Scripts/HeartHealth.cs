using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealth : MonoBehaviour
{
    public FloatReference HeartCurrentHealth;
    public float MaxHealth = 100;

    public BoolReference ShouldHealthDrain;
    public FloatReference HealthLossPerSecond;

    public bool HealthCriticalWarning = false;
    public float HealthCriticalThreshold = 50f;

    public bool IsDead = false;

    public AudioSource HeartAlertSource;
    public AudioClip HealthRestoreSound;

    public TooltipManager manager;

    public GameEvent GameOverEvent;

    private bool hasRemindedPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        HeartCurrentHealth.Value = MaxHealth;
    }

    void Update()
    {
        HeartCurrentHealth.Value -= (HealthLossPerSecond.Value * Time.deltaTime);

        if(HeartCurrentHealth.Value <= HealthCriticalThreshold && HealthCriticalWarning == false)
        {
            HealthCriticalWarning = true;
            RemindPlayerToSqueezeHeart();
        }else if(HeartCurrentHealth.Value > HealthCriticalThreshold && HealthCriticalWarning == true)
        {
            HealthCriticalWarning = false;
            StopRemindingPlayer();
        }

        if (HeartCurrentHealth.Value <= 0 && !IsDead)
        {
            HeartCurrentHealth.Value = 0;
            IsDead = true;
            // GAME OVER. DO GAMEOVER STUFF HERE.
            Debug.Log("Heart has died! Game over!");
            GameOverEvent.Raise();
        }
    }

    public void RemoveHealth(float amount)
    {
        HeartCurrentHealth.Value -= amount;
    }

    public void AddHealth(float amount)
    {
        HeartCurrentHealth.Value += amount;
        HeartAlertSource.PlayOneShot(HealthRestoreSound, 0.5f);
        if(HeartCurrentHealth.Value >= MaxHealth)
        {
            HeartCurrentHealth.Value = MaxHealth;
        }
    }

    private void RemindPlayerToSqueezeHeart()
    {
        Debug.LogWarning("Health critical! Squeeze heart!");
        HeartAlertSource.Play();

        if(!hasRemindedPlayer)
        {
            hasRemindedPlayer = true;
            Debug.Log("Remind Player!");
            manager.CreateTooltip("The heart's condition is critical! Grab it and repeatedly press 'E' to pump it!", 7f);
        }
    }

    private void StopRemindingPlayer()
    {
        if (hasRemindedPlayer)
            hasRemindedPlayer = false;

        HeartAlertSource.Stop();
    }
}
