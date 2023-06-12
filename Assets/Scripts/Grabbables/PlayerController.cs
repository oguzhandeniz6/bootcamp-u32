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

  

    private void Update()
    {
        //Throw tuþu için ---------------------------------------------------
        //Elinde item varken
        if (rightHand.childCount > 0)
        {
            //Space'e basarsa
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Space'e basma zamanýndan itibaren geçen zamaný tut
                holdStartTime = Time.time;
                //Fýrlatma animasyonuna baþla

            }
            //Space'den çekerse
            if (Input.GetKeyUp(KeyCode.Space))
            {

                //Geçen zamanýn max zamana uygun olduðunu checkle
                float passedTime = Time.time - holdStartTime;

                //Throwa geçmeden space býrakýldýysa
                if (passedTime < delayForThrowing)
                {
                    //Yere býrak
                    Drop();

                }
                //Throw süresini aþtýysa
                if (passedTime > delayForThrowing)
                {
                    //Fýrlat
                    Throw();
                }

            }

        }
        //Use tuþu için ----------------------------------------------------
        //Elinde obje varsa
        if (rightHand.childCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                rightHand.GetChild(0).GetComponent<Grabbable>().Use();


            }
        }
        //Elinde obje yoksa
        if (objectsInRadius.Count > 0 && rightHand.childCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp(FindNearestItem());
            }
        }



    }


    [SerializeField] private List<GameObject> objectsInRadius = new List<GameObject>();

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


    private void PickUp(GameObject pickedObject)
    {
        //Pick up animation trigger
        playerAnim.SetTrigger("onPickup");
        //Elin childi yapar
        pickedObject.transform.SetParent(rightHand);
        pickedObject.transform.localPosition = Vector3.zero;
        //Rigid body ve colllider
        EnableDisablePhysics(pickedObject, true);
    }

    private void Drop()
    {
        //Elin childini birakir
        var child = rightHand.GetChild(0);
        child.transform.SetParent(null);

        EnableDisablePhysics(child.gameObject, false);

    }

    private void EnableDisablePhysics(GameObject pickedObject, bool toggle)
    {
        pickedObject.GetComponent<Rigidbody>().isKinematic = toggle;
        pickedObject.GetComponent<MeshCollider>().enabled = !toggle;
    }

    //Þimdilik drop ile ayný
    private void Throw()
    {

        Drop();


    }

}

