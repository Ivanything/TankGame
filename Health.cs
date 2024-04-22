using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public float currentHealth;
    protected float maxHealth;
    public GameObject spawnOnDeath;
    private DamageOverlay playOnDamage;
    public int pointsOnDeath;
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
        if (playOnDamage) playOnDamage.PlayAnimation();

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

        ScoreScript.addScore(pointsOnDeath);

        GameManager.gm.PawnDied(this);

        Destroy(gameObject);
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(maxHealth, currentHealth);

        if (playOnDamage) playOnDamage.ChangeHealth();
    }

    public float healthRatio()
    {
        if (currentHealth >= maxHealth) return 1;

        return Mathf.Max((currentHealth - 5) / maxHealth, 0);
    }

    public void setDamageOverlay(DamageOverlay dov)
    {
        playOnDamage = dov;
    }

    public void iDamage(float amount)
    {
        TakeDamage(amount);
    }
}

interface IDamageable{
    void iDamage(float amount);
}