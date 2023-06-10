using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform rightHand;
    private GameObject heldObject;

    

    private void PickUp(GameObject pickedObject)
    {
        pickedObject.transform.SetParent(rightHand);
        pickedObject.transform.localPosition = Vector3.zero;
        heldObject = pickedObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressed");

            if (collision.gameObject.GetComponent<PickUpable>() != null)
            {
                Debug.Log("Colliding");
                PickUp(collision.gameObject);
            }
        }
    }




}
