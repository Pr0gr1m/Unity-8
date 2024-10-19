using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool canInsert = true;

    public UIItem savedUIItem;

    public void OnDrop(PointerEventData eventData)
    {
        if (!canInsert) return;

        RectTransform objectTransform = eventData.pointerDrag? eventData.pointerDrag.GetComponent<RectTransform>() : null;
        if(objectTransform)
        {
            objectTransform.anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
        }

        UIItem UIItem = eventData.pointerDrag? eventData.pointerDrag.GetComponent<UIItem>() : null;
        if (UIItem)
        {
            savedUIItem = UIItem;
            UIItem.parentInventorySlot = this;
        }
    }
}
