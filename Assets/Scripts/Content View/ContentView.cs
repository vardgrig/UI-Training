using UnityEngine;
using UnityEngine.UI;

public class ContentView : MonoBehaviour
{
    [SerializeField] Text _titleText;
    [SerializeField] Button _backButton;

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
        _titleText.text = _currentTab.TabName;
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
