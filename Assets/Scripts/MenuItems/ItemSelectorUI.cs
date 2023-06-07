using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemSelectedEvent : UnityEvent<MenuItemSO> { }

public class ItemSelectorUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LinkedText;
    MenuItemSO LinkedMenuItem;

    public ItemSelectedEvent OnItemSelected = new();

    public void Bind(MenuItemSO item, string title)
    {
        LinkedMenuItem = item;
        LinkedText.text = title;
        item.SetTitle(title);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelected()
    {
        OnItemSelected.Invoke(LinkedMenuItem);
    }
}
