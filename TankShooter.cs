using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : Shooter
{
    public GameObject projectile;
    public Controller controller;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public override void Shoot()
    {
        Projectile p = Instantiate(projectile, transform.position, transform.rotation).GetComponent<Projectile>();
        if (controller)
        {
            p.SetOwner(controller);
        }
    }
}