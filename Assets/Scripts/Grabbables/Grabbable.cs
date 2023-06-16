using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{

    public int maxDurability;
    public int currentDurability;
    //Bunu buraya yazmadan yapman�n yolunu bulabilir miyim acaba
    public PlayerController playerController;

    [Tooltip("Fırlatma katsayısı")]
    [SerializeField] public float throwCoefficient;

    private void Start()
    {
        currentDurability = maxDurability;
    }

    public virtual void OnGrabbed()
    {

    }

    public virtual void Use()
    {
       
    }

    public virtual void OnDropped()
    {
        
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