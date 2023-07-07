using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionCondition", menuName = "Questing/InteractionCondition")]
public class InteractCondition : ScriptableObject
{
    public List<Condition> conditions = new List<Condition>();

    public bool ConditionsAreMet()
    {
        foreach(Condition condition in conditions)
        {
            if (condition.isMet == false)
            {
                return false;
            }
        }

        return true;

    }

    public void ResetAllConditions()
    {
        foreach(Condition condition in conditions)
        {
            condition.ResetCondition();
        }
    }

}
