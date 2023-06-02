using UnityEngine;
using UnityEngine.EventSystems;

public class UIDropableSlot : MonoBehaviour, IDropHandler
{
    private UIDragableItem _item;
    private void Start()
    {
        if(transform.childCount > 0)
            _item = GetComponentInChildren<UIDragableItem>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        var otherDragableItem = otherItemTransform.GetComponent<UIDragableItem>();
        if (_item != null)
        {
            _item.transform.SetParent(otherDragableItem.ParentSlot.transform);
            _item.ParentSlot = otherItemTransform.parent.GetComponent<UIDropableSlot>();
            _item.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
        _item = otherDragableItem;
        _item.transform.SetParent(transform);
        _item.ParentSlot = this;
        _item.GetComponent<RectTransform>().localPosition = Vector3.zero;
    }
}