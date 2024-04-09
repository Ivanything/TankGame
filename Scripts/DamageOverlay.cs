using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverlay : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        GameManager.gm.player.GetComponent<Health>().playOnDamage = GetComponent<Animation>();
        Destroy(this);
    }
}