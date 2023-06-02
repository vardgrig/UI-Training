using UnityEngine;
using UnityEngine.UI;

public class PopupView : MonoBehaviour
{
    [SerializeField] Button _poupCloseButton;
    [SerializeField] PopupContentView _popupContent;
    [SerializeField] Animator _popupAnimator;

    private const string ANIMATOR_HIDE_KEY = "HidePopup";

    private void OnEnable()
    {
        _poupCloseButton.onClick.AddListener(ClosePopup);
    }

    private void OnDisable()
    {
        _poupCloseButton.onClick.RemoveListener(ClosePopup);
    }

    public void SetPopupContentSettings(PopupContentSettings popupContentSettings)
    {
        _popupContent.SetPopupContent(popupContentSettings);
    }

    private void ClosePopup()
    {
        _popupAnimator.SetTrigger(ANIMATOR_HIDE_KEY);
    }

    public void DestroyPopup()
    {
        Destroy(this.gameObject);
    }
}
