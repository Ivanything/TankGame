using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float currentHealth;
    protected float maxHealth;
    public GameObject spawnOnDeath;
    public Animation playOnDamage;
    AudioSource au;
    void Start()
    {
        au = GetComponent<AudioSource>();
        maxHealth = currentHealth;
    }
    public void TakeDamage(float dam)
    {
        currentHealth -= dam;

        if (au) au.Play();
        if (playOnDamage) playOnDamage.Play();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        print("I'm ded");

        if (spawnOnDeath)
        {
            Instantiate(spawnOnDeath, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
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