using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [SerializeField] List<TabButton> _tabButtonsList;
    [SerializeField] Color _tabIdleColor;
    [SerializeField] Color _tabActiveColor;
    [SerializeField] TabButton _selectedTab;
    [SerializeField] List<GameObject> _contentsList;
    [SerializeField] Text _titleText;
    
    public void Start()
    {
        _selectedTab.BackgroundImage.color = _tabActiveColor;
    }
    public void Subscribe(TabButton button)
    {
        _tabButtonsList ??= new List<TabButton>();
        _tabButtonsList.Add(button);
    }

    public void OnTabSelected(TabButton button)
    {
        _selectedTab = button;
        ResetTabs();
        button.BackgroundImage.color = _tabActiveColor;
        int index = button.transform.GetSiblingIndex() + 1;
        for (int i = 0; i < _contentsList.Count; ++i)
        {
            if (i == index - 1)
                _contentsList[i].SetActive(true);
            else
                _contentsList[i].SetActive(false);
        }
        _titleText.text = _selectedTab.TabName;
    }
    public void ResetTabs()
    {
        foreach (TabButton button in _tabButtonsList)
        {
            if (_selectedTab != null && button == _selectedTab) { continue; }
            button.BackgroundImage.color = _tabIdleColor;
        }
    }
}