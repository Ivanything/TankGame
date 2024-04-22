using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperPickup : Pickup
{
    public GameObject shooter;
    public override void collect(Collider collector)
    {
        Shooter previousShooter = collector.GetComponent<TankPawn>().shooter;
        TemporaryShooter currentTemporaryShooter = previousShooter.gameObject.GetComponent<TemporaryShooter>();
        if (currentTemporaryShooter)
        {
            if (currentTemporaryShooter.bullet == shooter.GetComponent<TemporaryShooter>().bullet)
            {
                currentTemporaryShooter.AddShots(1);
            }
            else
            {
                return;
            }
        }
        else
        {
            TemporaryShooter ts = Instantiate(shooter, previousShooter.transform.position, previousShooter.transform.rotation, previousShooter.transform.parent).GetComponent<TemporaryShooter>();
            ts.SetUpShooter(1, previousShooter, collector.GetComponent<TankPawn>());
        }

        Destroy(gameObject);
    }

    public override bool isValidCollector(Collider collector)
    {
        return collector.GetComponent<TankPawn>();
    }
}