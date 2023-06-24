using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItemImageName : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text itemText;

    public void ChangeItemImageText(Component sender, object data)
    {
        if (data is Grabbable)
        {
            Grabbable grabbedObject = (Grabbable) data;
            itemImage.sprite = grabbedObject.icon;
            itemText.text = grabbedObject.itemName;

        }


    }

    public void ItemDropped(Component sender, object data)
    {
        itemImage.sprite = null;
        itemText.text = "";
    }


}
