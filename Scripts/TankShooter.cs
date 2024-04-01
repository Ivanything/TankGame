using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public GameObject projectile;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public override void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}