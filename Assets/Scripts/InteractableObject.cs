using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class InteractableObject : MonoBehaviour, IInteractable
{
    [TextArea(5,5)]
    [SerializeField] string dialogue;
    public GameEvent onDialogue;
    [Tooltip("Bu seye interact etmek icin belirli kosullari tamamlamak gerekiyorsa koyun")]
    public InteractCondition interactCondition;
    public UnityEvent onConditionsMet;
    [Tooltip("Bu seye interact etmek bir gorevi tamamlayacaksa bunu koyun")]
    public Condition condition;

    public void Interact(int id)
    {
        if (interactCondition != null)
        {
            if (interactCondition.ConditionsAreMet())
            {
                onConditionsMet.Invoke();
            }
            else
            {
                onDialogue.Raise(this, dialogue);
            }
            return;
        }
        onDialogue.Raise(this, dialogue);
        if (condition != null)
        {
            condition.isMet = true;
        }
    }





}
