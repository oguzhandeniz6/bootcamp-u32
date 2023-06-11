using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{

    public int maxDurability;
    public int currentDurability;
    public bool isBroken = false;
   
    private void Start()
    {
        currentDurability = maxDurability;
    }

    public virtual void Use() 
    {
        if (isBroken == true) 
        {
            Debug.Log(this.gameObject + " is broken.");
            return; 
        } 
        currentDurability -= 1;
        CheckIfBroken();
    }

    private void CheckIfBroken()
    {
        if (currentDurability <= 0)
        {

            isBroken = true;
        }
    }

}
