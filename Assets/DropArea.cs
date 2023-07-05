using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] GameEvent onFeedSuccesful;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Grabbable>(out Grabbable droppedItem))
        {
   
            if (droppedItem.itemName == itemName)
            {
                
                Debug.Log("Feeding succesful");
                onFeedSuccesful.Raise(null, null);
            }

        }
    }






}
