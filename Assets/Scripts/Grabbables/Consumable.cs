using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Grabbable
{

    public enum ConsumableType { Health, Stamina };
    public ConsumableType type;
    public float amount;

    public override void Use()
    {
        base.Use();
        if (base.isBroken)
        {
            return;
        }

        Debug.Log("restored " + amount + " health.");
        Debug.Log(base.currentDurability + "/" + base.maxDurability);
    }





}
