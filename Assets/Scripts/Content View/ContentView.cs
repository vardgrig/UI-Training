using UnityEngine;
using UnityEngine.UI;

public class ContentView : MonoBehaviour
{
    [SerializeField] Button _backButton;

    [SerializeField] Transform _popupParentTransform;
    [SerializeField] Transform _viewParentTransform;

    public Transform PopupParentTransform { get { return _popupParentTransform; } }
    public Transform ViewParentTransform { get { return _viewParentTransform; } }

    private Content _currentContent;
    private Content _previousContent => _currentContent.PreviousContent;

    private TabButton _currentTab;

    private void OnEnable()
    {
        _backButton.onClick.AddListener(BackToPreviousContent);
    }

    private void BackToPreviousContent()
    {
        _currentContent = _previousContent;
        CheckForBackButton();
    }

    private void CheckForBackButton()
    {
        if(_previousContent == null)
        {
            _backButton.gameObject.SetActive(false);
        }
        else
        {
            _backButton.gameObject.SetActive(true);
        }
    }
}