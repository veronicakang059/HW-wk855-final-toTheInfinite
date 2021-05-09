using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AborbShield : BaseShield
{
    public override float AdjustDamage(float damage)
    {
        return -damage;
    }
}
