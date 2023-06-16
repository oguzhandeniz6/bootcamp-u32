using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Grabbable
{

    public enum ConsumableType { Health, Energy };
    public ConsumableType type;
    public bool isDrink;
    public float amount;

    public Consumable()
    {
        throwCoefficient = 30f;
    }

    public override void Use()
    {
        

        //Consumable t�r�ne g�re anim oynat ve sonradan can/enerji ver
        switch (type)
        {
            case ConsumableType.Health:
                //Health doldur buraya
                if (isDrink)
                {
                    base.playerController.playerAnim.SetTrigger("onDrink");
                }
                else
                {
                    base.playerController.playerAnim.SetTrigger("onEat");
                }
                break;
            case ConsumableType.Energy:
                //Energy doldur buraya
                if (isDrink)
                {
                    base.playerController.playerAnim.SetTrigger("onDrink");
                }
                else
                {
                    base.playerController.playerAnim.SetTrigger("onEat");
                }
                break;
            default:
                break;
        }

        //Durability azalt
        base.currentDurability -= 1;

        //K�r�k m� de�il mi kontrol et
        //k�r�ksa yok et
        if (CheckIfBroken())
        {
            playerController.objectsInRadius.Remove(this.gameObject);
            playerController.Drop();
            Destroy(this.gameObject);
        }
    
        Debug.Log("restored " + amount + " health.");
        Debug.Log(base.currentDurability + "/" + base.maxDurability);
    }





}
