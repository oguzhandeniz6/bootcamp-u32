using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemDurability : MonoBehaviour
{
    [SerializeField] GameObject durabilityPointPrefab;
    private List<Image> durabilityPoints = new List<Image>();
    private List<bool> durabilityStates = new List<bool>();

    public void GetItemData(Component sender, object data)
    {
        if (data is Grabbable)
        {
            Grabbable grabbedObj = (Grabbable)data;
            SetDurability(grabbedObj.maxDurability, grabbedObj.currentDurability);
        }
    }

    private void SetDurability(int maxDurability, int currentDurability)
    {
        ClearDurabilityPoints(null, null);
        CreateDurabilityPoints(maxDurability);
        UpdateDurabilityUI(currentDurability);
    }

    public void ClearDurabilityPoints(Component sender, object data)
    {


        foreach (Image durabilityPoint in durabilityPoints)
        {
            Destroy(durabilityPoint.gameObject);
        }
        durabilityPoints.Clear();
        durabilityStates.Clear();
    }

    private void CreateDurabilityPoints(int maxDurability)
    {
        for (int i = 0; i < maxDurability; i++)
        {
            GameObject durabilityPointObj = Instantiate(durabilityPointPrefab, transform);
            Image durabilityPoint = durabilityPointObj.GetComponent<Image>();
            durabilityPoints.Add(durabilityPoint);
            durabilityStates.Add(true); // All points initially set to true (green)
        }
    }

    private void UpdateDurabilityUI(int currentDurability)
    {
        for (int i = 0; i < durabilityPoints.Count; i++)
        {
            Image durabilityPoint = durabilityPoints[i];

            if (i >= currentDurability)
            {
                durabilityStates[i] = false; // Mark the box as used (red)
                durabilityPoint.color = Color.red;
            }
            else
            {
                durabilityStates[i] = true; // Mark the box as available (green)
                durabilityPoint.color = Color.green;
            }
        }
    }

    public void DecreaseDurability(Component sender, object data)
    {
        //datadan kaç can kaybedildigini cekebiliriz sonrasi icin
        //alta bir for loop koyarak o halledilir

        int lastGreenIndex = FindLastGreenDurabilityIndex();

        if (lastGreenIndex >= 0)
        {
            durabilityStates[lastGreenIndex] = false; // Mark the box as used (red)
            durabilityPoints[lastGreenIndex].color = Color.red;
        }
    }

    private int FindLastGreenDurabilityIndex()
    {
        for (int i = durabilityStates.Count - 1; i >= 0; i--)
        {
            if (durabilityStates[i])
            {
                return i;
            }
        }

        return -1; // No green durability box found
    }
}