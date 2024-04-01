using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float currentHealth;
    float maxHealth;
    void Start()
    {
        maxHealth = currentHealth;
    }
    public void TakeDamage(float dam)
    {
        currentHealth -= dam;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        print("I'm ded");
    }

    public float healthRatio()
    {
        return currentHealth / maxHealth;
    }



    public void iDamage(float amount)
    {
        TakeDamage(amount);
    }
}

interface IDamageable{
    void iDamage(float amount);
}