using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TabGroup _tabGroup;
    [SerializeField] Image _backgroundImage;
    [SerializeField] string _tabName;

    public TabGroup TabGroup { get { return _tabGroup; } }
    public Image BackgroundImage { get { return _backgroundImage; } }
    public string TabName { get { return _tabName; } }

    private void Start()
    {
        TabGroup.Subscribe(this);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        TabGroup.OnTabSelected(this);
        print(gameObject.name);
    }
}