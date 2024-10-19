using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private CanvasGroup group;
    [SerializeField] private RectTransform Transform;

    public InventorySlot parentInventorySlot;
    public ItemTypes ItemType;
    public string Description;

    private void Awake()
    {
        Transform = GetComponent<RectTransform>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (parentInventorySlot) 
        {
            parentInventorySlot.savedUIItem = null;
            parentInventorySlot = null;
        }

        group.alpha = 0.75f;
        group.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        group.alpha = 1f;
        group.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Transform.anchoredPosition += eventData.delta / transform.parent.GetComponent<RectTransform>().lossyScale;
    }
}

[Serializable]
public enum ItemTypes
{
    None, HealthPot, SpeedPot, Glass
}