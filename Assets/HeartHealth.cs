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
        }

        if (HeartCurrentHealth.Value <= 0 && !IsDead)
        {
            HeartCurrentHealth.Value = 0;
            IsDead = true;
            // GAME OVER. DO GAMEOVER STUFF HERE.
            Debug.Log("Heart has died! Game over!");
        }
    }

    public void RemoveHealth(float amount)
    {
        HeartCurrentHealth.Value -= amount;
    }

    public void AddHealth(float amount)
    {
        HeartCurrentHealth.Value += amount;
        if(HeartCurrentHealth.Value >= MaxHealth)
        {
            HeartCurrentHealth.Value = MaxHealth;
        }
    }

    private void RemindPlayerToSqueezeHeart()
    {
        Debug.LogWarning("Health critical! Squeeze heart!");
    }
}
