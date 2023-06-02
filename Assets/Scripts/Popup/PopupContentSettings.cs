using UnityEngine;

[CreateAssetMenu(fileName = "PopupSettings", menuName = "Popup/Popup Settings")]
public class PopupContentSettings : ScriptableObject
{
    [TextArea]
    [SerializeField] string _text;
    public string Text { get { return _text; } }
}