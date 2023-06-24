using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIItemDurability : MonoBehaviour
{
    private List<GameObject> durabilityPoints = new List<GameObject>();
    [SerializeField] GameObject durabilityPointPrefab;
    int maxDurabilityReceived;
    int currentDurabilityReceived;

    public void GetCurrentAndMaxDurability(Component sender, object data)
    {
        if (data is Grabbable)
        {
            Grabbable grabbedItem = (Grabbable)data;
            maxDurabilityReceived = grabbedItem.maxDurability;
            currentDurabilityReceived = grabbedItem.currentDurability;

        }

        ClearDurabilityPoints();

        SpawnDurabilityPoints();

        //AdjustCurrentDurability();
    }

    private void SpawnDurabilityPoints()
    {
        for (int i = 0; i < maxDurabilityReceived; i++)
        {
            GameObject spawnedPoint = Instantiate(durabilityPointPrefab, transform);
            durabilityPoints.Add(spawnedPoint);
        }
    }
    private void ClearDurabilityPoints()
    {
        for (int i = 0; i < durabilityPoints.Count; i++)
        {
            Destroy(durabilityPoints[i].gameObject);
        }
    }

    public void ItemDropped(Component sender, object data)
    {
        ClearDurabilityPoints();
    }

    private void AdjustCurrentDurability()
    {
        int currentDurability = currentDurabilityReceived;

        for (int i = 0; i < currentDurability; i++)
        {
            durabilityPoints[i].transform.GetChild(0).GetComponent<Image>().color = Color.green;
        }
    }

}
