using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Grabbable
{

    public override void OnGrabbed()
    {
        playerController.playerAnim.SetBool("hasTorch", true);
        base.OnGrabbed();
    }

    public override void OnDropped()
    {
        base.OnDropped();
        playerController.playerAnim.SetBool("hasTorch", false);
    }

    public override void Use()
    {
        //Playeranim = lights an object
        //lights the torch on the wall
        playerController.playerAnim.SetTrigger("onAttack");


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable hit))
        {
            hit.Damage();
            LoseDurability(1);
        }

    }

}
