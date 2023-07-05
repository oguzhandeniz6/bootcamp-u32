using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private bool toggle;
    [SerializeField] private GameObject panel;

    public void Interact()
    {
        SwitchOnPanel();
    }

    public void SwitchOnPanel()
    {
        toggle = !toggle;

        panel.SetActive(toggle);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }

}
