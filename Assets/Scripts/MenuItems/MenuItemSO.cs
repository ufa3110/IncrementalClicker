using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemSO : MonoBehaviour
{
    // Start is called before the first frame update

    public string Title { get; private set; }

    void Start()
    {

    }

    public void SetTitle(string title)
    {
        this.Title = title;
    }

    public MenuItemSO(string title)
    {
        this.Title = title;
    }

}
