using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Condition", menuName = "Questing/Condition")]
public class Condition : ScriptableObject
{
    public bool isMet;

    public void ResetCondition()
    {
        isMet = false;
    }

}
