using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Grabbable
{
    [SerializeField] GameObject lightObject;

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
        IInteractable interactable = FindNearestInteractable();
        if (interactable != null)
        {
            interactable.Interact();
            LoseDurability(1);
        }
        else
        {
            playerController.playerAnim.SetTrigger("onAttack");
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable hit))
        {
            hit.Damage();
            LoseDurability(1);
        }

        

    }

    #region Trigger
    private List<GameObject> interactableObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactableObject))
        {
            interactableObjects.Add(other.gameObject);
        }
    }

    private IInteractable FindNearestInteractable()
    {
        GameObject nearestInteractableGO = null;
        float nearestDistance = Mathf.Infinity;

        foreach(GameObject interactable in interactableObjects)
        {

            float distance = Vector3.Distance(transform.position, interactable.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestInteractableGO = interactable;
            }
        }

        if (nearestInteractableGO == null)
        {
            return null;
        }

        if ( nearestInteractableGO.TryGetComponent<IInteractable>(out IInteractable nearestInteractable))
        {
            return nearestInteractable;
        }
        else
        {
            return null;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactableObject))
        {
            if (interactableObjects.Contains(other.gameObject))
            {
                interactableObjects.Remove(other.gameObject);
            }
        }
    }

    #endregion
}
