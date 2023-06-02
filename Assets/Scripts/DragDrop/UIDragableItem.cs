using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] Canvas _mainCanvas;
    [SerializeField] CanvasGroup _canvasGroup;
    private UIDropableSlot _parentSlot;

    public UIDropableSlot ParentSlot { get { return _parentSlot; } set { _parentSlot = value; } }

    private void Start()
    {
        _parentSlot = transform.parent.GetComponent<UIDropableSlot>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        _parentSlot = slotTransform.GetComponent<UIDropableSlot>();
        slotTransform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
    }

}
