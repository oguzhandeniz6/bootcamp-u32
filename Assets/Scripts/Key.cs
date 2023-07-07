using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Grabbable
{

    public int keyId;

    public override void Use()
    {
        if (playerController.interactablesInRadius.Count <= 0)
        {
            return;
        }
        playerController.FindNearestInteractable().GetComponent<IInteractable>().Interact(keyId);
    }

    


}
