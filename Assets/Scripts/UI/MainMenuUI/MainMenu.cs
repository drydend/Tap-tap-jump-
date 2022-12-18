using System.Collections;
using UnityEngine;

public class MainMenu : UIMenu
{
    [SerializeField]
    private GameObject _menu;

    public override void Close()
    {
        _menu.SetActive(false);
    }

    public override void Open()
    {
        _menu.SetActive(true);
    }
}
