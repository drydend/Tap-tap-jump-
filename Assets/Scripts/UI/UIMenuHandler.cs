using System.Collections.Generic;
using UnityEngine;

public class UIMenuHandler : MonoBehaviour
{
    [SerializeField]
    private UIMenu _startMenu;

    private Stack<UIMenu> _openedMenus = new Stack<UIMenu>();

    public void Start()
    {
        _startMenu.Open();
        _openedMenus.Push(_startMenu);
    }

    public void OpenMenu(UIMenu menu)
    {
        _openedMenus.Peek().Close();
        menu.Open();

        _openedMenus.Push(menu);
    }

    public void BackToPreviousMenu()
    {
        if(_openedMenus.Count < 1)
        {
            return;
        }

        _openedMenus.Pop().Close();
        _openedMenus.Peek().Open();
    }
}
