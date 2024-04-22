using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryShooter : Shooter
{
    Shooter previousShooter;
    TankPawn thisPawn;
    public GameObject bullet;
    public int bulletAmount = 1;
    AudioSource au;

    void Start()
    {
        au = GetComponent<AudioSource>();
    }
    public override void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        bulletAmount--;
        if (bulletAmount <= 0)
        {
            thisPawn.shooter = previousShooter;
            Destroy(gameObject);
        }
    }

    public void SetUpShooter(int amount, Shooter lastSh, TankPawn pan)
    {
        previousShooter = lastSh;
        thisPawn = pan;
        bulletAmount = amount;
        pan.shooter = this;
    }
    public void AddShots(int amount)
    {
        bulletAmount += amount;
        au.Play();
    }
}