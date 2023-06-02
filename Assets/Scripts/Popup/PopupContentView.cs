using UnityEngine;
using UnityEngine.UI;

public class PopupContentView : MonoBehaviour
{
    [SerializeField] Text _popupContentText;
    private PopupContentSettings _popupContentSettings;

    public void SetPopupContent(PopupContentSettings popupContentSettings)
    {
        _popupContentSettings = popupContentSettings;
        UpdateContent();
    }
    private void UpdateContent()
    {
        if (_popupContentSettings == null) { return; }
        _popupContentText.text = _popupContentSettings.Text;
    }
}