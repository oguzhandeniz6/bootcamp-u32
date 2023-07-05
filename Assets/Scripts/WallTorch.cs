using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTorch : MonoBehaviour, IInteractable
{
    [SerializeField] private Light light;



    public void Interact(int id)
    {

        light.gameObject.SetActive(true);
    }

   


}
