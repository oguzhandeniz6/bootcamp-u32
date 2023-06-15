using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform rightHand;

    [Tooltip("Fýrlatma ve yere býrakmayý ayýran delay süresi")]
    [SerializeField] private float delayForThrowing = 0.3f;
    private float holdStartTime = 0;
    public Animator playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    float useDelay;

    private void Update()
    {
        useDelay -= Time.deltaTime;
        HandleThrowing();

        
            HandleItemPickup();
            HandleItemUsage();
        
    }

    private void HandleThrowing()
    {
        if (useDelay <= 0)
        {
            if (rightHand.childCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    holdStartTime = Time.time;
                    // Start throwing animation
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    float passedTime = Time.time - holdStartTime;

                    if (passedTime < delayForThrowing)
                    {
                        Drop();
                    }
                    else if (passedTime > delayForThrowing)
                    {
                        Throw();
                    }
                }
            }
        }
    }

    


    private void HandleItemUsage()
    {
        if (useDelay <= 0)
        {

            if (rightHand.childCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    useDelay = 1;
                    rightHand.GetChild(0).GetComponent<Grabbable>().Use();
                }
            }
        }
    }

    private void HandleItemPickup()
    {
        if (objectsInRadius.Count > 0 && rightHand.childCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                useDelay = 1;
                PickUp(FindNearestItem());
            }
        }
    }


    #region Trigger Kýsmý

    [SerializeField] public List<GameObject> objectsInRadius = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<Grabbable>(out Grabbable triggerObject))
        {

            objectsInRadius.Add(other.gameObject);


        }

    }


    private GameObject FindNearestItem()
    {

        GameObject nearestItem = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject go in objectsInRadius)
        {
            
            float distance = Vector3.Distance(transform.position, go.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestItem = go;
            }

        }

        return nearestItem;

    }

    private void OnTriggerExit(Collider other)
    {

        if (objectsInRadius.Contains(other.gameObject))
        {

            objectsInRadius.Remove(other.gameObject);
        }
    }

#endregion
    private void PickUp(GameObject pickedObject)
    {
        //PlayerControlleri objeye geçirir
        pickedObject.GetComponent<Grabbable>().playerController = this;

        //Pick up animation trigger
        playerAnim.SetTrigger("onPickup");

        //Elin childi yapar
        pickedObject.transform.SetParent(rightHand);
        pickedObject.transform.localPosition = Vector3.zero;
        pickedObject.transform.localRotation = Quaternion.identity;

        //Rigid body ve colllider
        EnableDisablePhysics(pickedObject, true);
    }

    public void Drop()
    {
        //PlayerControlleri objeden alýr
        rightHand.GetChild(0).GetComponent<Grabbable>().playerController = null;

        //Elin childini birakir
        var child = rightHand.GetChild(0);
        child.transform.SetParent(null);

        EnableDisablePhysics(child.gameObject, false);

    }

    private void EnableDisablePhysics(GameObject pickedObject, bool toggle)
    {
        
        pickedObject.GetComponent<Rigidbody>().isKinematic = toggle;
        
        if (pickedObject.GetComponent<MeshCollider>() != null)
        {
            pickedObject.GetComponent<MeshCollider>().enabled = !toggle;
        }
        else
        {
            pickedObject.GetComponentInChildren<MeshCollider>().enabled = !toggle;
        }
    }

    //Þimdilik drop ile ayný
    private void Throw()
    {

        Drop();


    }

    public void AttackEnter()
    {
        if (rightHand.GetChild(0) != null)
        {
            rightHand.GetChild(0).GetComponentInChildren<MeshCollider>().enabled = true;
        }
    }

    public void AttackExit()
    {
        if (rightHand.GetChild(0) != null)
        {
            rightHand.GetChild(0).GetComponentInChildren<MeshCollider>().enabled = false;
        }
    }

}

