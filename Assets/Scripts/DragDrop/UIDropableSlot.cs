using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDropableSlot : MonoBehaviour, IDropHandler
{
    private UIDragableItem _currentItem;
    public UIDragableItem CurrentItem { set { _currentItem = value; } }

    private void Start()
    {
        if(transform.childCount > 0)
            _currentItem = GetComponentInChildren<UIDragableItem>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        if (!otherItemTransform.TryGetComponent<UIDragableItem>(out var otherDragableItem))
            return;
        
        if (_currentItem != null)
            SwapCurrentItem(otherDragableItem, otherItemTransform);
        else
            EmptyOtherSlot(otherDragableItem.ParentSlot);

        ReplaceCurrentItem(otherDragableItem);
    }

    private void SwapCurrentItem(UIDragableItem otherItem, Transform otherItemTransform)
    {
        _currentItem.transform.SetParent(otherItem.ParentSlot.transform);
        _currentItem.ParentSlot = otherItemTransform.parent.GetComponent<UIDropableSlot>();
        _currentItem.ParentSlot.CurrentItem = _currentItem;
        _currentItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

    private void ReplaceCurrentItem(UIDragableItem otherItem)
    {
        _currentItem = otherItem;
        _currentItem.transform.SetParent(transform);
        _currentItem.ParentSlot = this;
        _currentItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

    private void EmptyOtherSlot(UIDropableSlot slot)
    {
        slot.CurrentItem = null;
    }
}