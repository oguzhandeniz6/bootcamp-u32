using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public Sprite icon;
    public string itemName;

    public int maxDurability;
    public int currentDurability;
    //Bunu buraya yazmadan yapmanin yolunu bulabilir miyim acaba
    public PlayerController playerController;

    //Events
    [Header("Events")]
    public GameEvent onItemGrabbed;
    public GameEvent onItemDropped;
    public GameEvent onDurabilityLost;

    [Tooltip("Fırlatma katsayısı")]
    [SerializeField] public float throwCoefficient;

    private void Start()
    {
        currentDurability = maxDurability;
    }

    public virtual void OnGrabbed()
    {
        //Objeyi atesle
        onItemGrabbed.Raise(this, this);
      
    }

    public virtual void Use()
    {
       
    }

    public virtual void OnDropped()
    {
        onItemDropped.Raise(null, null);
    }

    public void LoseDurability(int amount)
    {
        currentDurability -= amount;
        onDurabilityLost.Raise(null, amount);
        if (CheckIfBroken())
        {
            playerController.objectsInRadius.Remove(this.gameObject);
            playerController.Drop();
            Destroy(this.gameObject);
        }
    }

    public bool CheckIfBroken()
    {
        if (currentDurability <= 0)
        {
            return true;

        }
        return false;
    }

}