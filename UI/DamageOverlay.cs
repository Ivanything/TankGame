using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageOverlay : MonoBehaviour
{
    public Transform healthBar;
    float fullHealthSize;
    Animation a;
    Health playerHealth;
    IEnumerator Start()
    {
        a = GetComponent<Animation>();
        fullHealthSize = healthBar.localScale.x;
        yield return new WaitForEndOfFrame();
        playerHealth = GameManager.gm.player.GetComponent<Health>();
        playerHealth.setDamageOverlay(this);
    }
    void Update()
    {
        if (Time.frameCount % 20 != 0) return;

        if (!GameManager.gm.player) return;

        playerHealth = GameManager.gm.player.GetComponent<Health>();
        playerHealth.setDamageOverlay(this);
    }
    public void PlayAnimation()
    {
        a.Play();
        ChangeHealth();
    }
    public void ChangeHealth()
    {
        if (!playerHealth) return;

        Vector3 size = healthBar.localScale;
        size.x = playerHealth.healthRatio() * fullHealthSize;
        healthBar.localScale = size;
    }
}