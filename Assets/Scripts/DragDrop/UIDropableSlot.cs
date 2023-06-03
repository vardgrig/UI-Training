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
        var otherDragableItem = otherItemTransform.GetComponent<UIDragableItem>();
        if (otherDragableItem == null)
            return;
        if (_currentItem != null)
        {
            SwapCurrentItem(otherDragableItem, otherItemTransform);
        }
        else
        {
            EmptyOtherSlot(otherDragableItem.ParentSlot);
        }
        _currentItem = otherDragableItem;
        _currentItem.transform.SetParent(transform);
        _currentItem.ParentSlot = this;
        _currentItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

    private void SwapCurrentItem(UIDragableItem otherItem, Transform otherItemTransform)
    {
        _currentItem.transform.SetParent(otherItem.ParentSlot.transform);
        _currentItem.ParentSlot = otherItemTransform.parent.GetComponent<UIDropableSlot>();
        _currentItem.ParentSlot.CurrentItem = _currentItem;
        _currentItem.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }
    private void EmptyOtherSlot(UIDropableSlot slot)
    {
        slot.CurrentItem = null;
    }
}