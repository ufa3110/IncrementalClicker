using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRootUI : MonoBehaviour
{
    List<MenuItemSO> MenuItems;

    [SerializeField] GameObject MenuItemPrefab;
    [SerializeField] Transform ItemSelectorRoot;
    public Animator Animator;

    private bool isShown = true;

    // Start is called before the first frame update
    void Start()
    {
        var scriptObject = MenuItemPrefab.GetComponent<MenuItemSO>();
        MenuItems = new()
        {
            new MenuItemSO("title1"),
            new MenuItemSO("title2"),
            new MenuItemSO("title3"),
            new MenuItemSO("title4"),
        };

        foreach (var item in MenuItems)
        {
            var selectorGO = Instantiate(MenuItemPrefab, Vector3.zero, Quaternion.identity, ItemSelectorRoot);
            var selectorScript = selectorGO.GetComponent<ItemSelectorUI>();
            selectorScript.Bind(item, item.Title);
            selectorScript.OnItemSelected.AddListener(OnItemSelected);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchExpanded()
    {
        Debug.Log("EXPAND");
        isShown = !isShown;
        Animator.SetBool("Expand", isShown);
        Animator.SetBool("Collapse", !isShown);
    }

    public void OnItemSelected(MenuItemSO menuItem)
    {
        Debug.Log(menuItem.Title);
    }
}
