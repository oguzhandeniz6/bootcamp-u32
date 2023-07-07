using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePanel : MonoBehaviour, IInteractable
{
    private bool toggle;
    [SerializeField] private GameObject panel;

    public void Interact(int id)
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
