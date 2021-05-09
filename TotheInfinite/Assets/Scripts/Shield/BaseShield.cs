using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShield : MonoBehaviour
{
    public float shieldStrength = 50;

    public virtual float AdjustDamage(float damage)
    {
        if (shieldStrength >0)
        {
            shieldStrength -= damage;
            return 0;
        }
        else
        {
            return damage;
        }
    }


}
