using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateAnimation : MonoBehaviour
{
    public string[] anims;
    int i = 0;
    Animation a;
    void Start()
    {
        a = GetComponent<Animation>();
    }
    public void PlayAnimation()
    {
        a.Play(anims[i]);
        i++;
        i %= anims.Length;
    }
}