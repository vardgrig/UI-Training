using UnityEngine;

public class PopupOpener : ContentOpener
{
    [SerializeField] PopupContentSettings _popupContentSettings;
    [SerializeField] GameObject _popupPrefab;
    [SerializeField] ContentView _contentView;

    public override void OpenContent()
    {
        var go = Instantiate(_popupPrefab, _contentView.PopupParentTransform);
        go.GetComponent<PopupView>().SetPopupContentSettings(_popupContentSettings);
    }
}
