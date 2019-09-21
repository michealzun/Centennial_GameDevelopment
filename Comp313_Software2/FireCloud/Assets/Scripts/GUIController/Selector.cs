using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Selector : MonoBehaviour
{
    public string title;
    public TextMeshProUGUI textTitle;
    public TextMeshProUGUI textItemName;
    public Button buttonPrevious;
    public Button buttonNext;
    public Image icon;
    public SelectableItem[] SelectableItems;

    private int _selectedIndex;
    public int SelectedIndex
    {
        get
        {
            return this._selectedIndex;
        }
        set
        {
            this._selectedIndex = value;
            SetSelection(this._selectedIndex);
        }
    }

    void Start()
    {
        textTitle.text = title;
        buttonPrevious.onClick.RemoveAllListeners();
        buttonPrevious.onClick.AddListener(OnPreviousClicked);
        buttonNext.onClick.RemoveAllListeners();
        buttonNext.onClick.AddListener(OnNextClicked);
    }

    void OnPreviousClicked()
    {
        if(SelectedIndex == 0)
        {
            SelectedIndex = SelectableItems.Length - 1;
        }
        else
        {
            SelectedIndex--;
        }
    }

    void OnNextClicked()
    {
        if (SelectedIndex == SelectableItems.Length - 1)
        {
            SelectedIndex = 0;
        }
        else
        {
            SelectedIndex++;
        }
    }

    void SetSelection(int i)
    {
        if (i < SelectableItems.Length)
        {
            icon.sprite = SelectableItems[i].sprite;
            textItemName.text = SelectableItems[i].itemName;
        }
    }
}
