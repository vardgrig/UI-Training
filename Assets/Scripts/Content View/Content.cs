using UnityEngine;
using UnityEngine.UI;

public class Content : MonoBehaviour
{
    [SerializeField] Button _contentButton;
    [SerializeField] ContentOpener _contentOpener;
    private Content _previousContent;

    private void OnEnable()
    {
        _contentButton.onClick.AddListener(OpenNewContent);
    }

    private void OnDisable()
    {
        _contentButton.onClick.RemoveListener(OpenNewContent);
    }

    private void OpenNewContent()
    {
        _contentOpener.OpenContent();
    }

    public Content PreviousContent { get { return _previousContent; } }
}
