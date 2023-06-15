using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Grabbable
{

    MeshCollider swordHitbox;

    public override void OnGrabbed()
    {
        playerController.playerAnim.SetBool("hasWeapon", true);
        base.OnGrabbed();
    }

    public override void OnDropped()
    {
        base.OnDropped();
        playerController.playerAnim.SetBool("hasWeapon", false);
    }

    public override void Use()
    {
        playerController.playerAnim.SetTrigger("onAttack");
        
    }




}
