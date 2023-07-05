using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [TextArea(5,5)]
    [SerializeField] string dialogue;
    public GameEvent onDialogue;

    public void Interact(int id)
    {
        onDialogue.Raise(this, dialogue);
    }





}
