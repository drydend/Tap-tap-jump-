using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuHandler : MonoBehaviour
{
    [SerializeField]
    private UIMenu _startMenu;

    private Stack<UIMenu> _openedMenus = new Stack<UIMenu>();

    public void Start()
    {
        if (_startMenu != null)
        {
            StartCoroutine(_startMenu.Open());
            _openedMenus.Push(_startMenu);
        }
    }

    public void OpenMenu(UIMenu menu)
    {
        if (_openedMenus.TryPeek(out UIMenu currentMenu) && currentMenu.IsAnimated)
        {
            return;
        }

        StartCoroutine(OpenMenuRoutine(menu));
    }

    public void BackToPreviousMenu()
    {
        if (_openedMenus.TryPeek(out UIMenu currentMenu) && currentMenu.IsAnimated)
        {
            return;
        }

        if (_openedMenus.Count < 1)
        {
            return;
        }

        StartCoroutine(BackToPreviousMenuRoutine());
    }

    public IEnumerator CloseCurrentMenu()
    {
        yield return _openedMenus.Pop().Close();
    }

    private IEnumerator OpenMenuRoutine(UIMenu menu)
    {
        if (_openedMenus.Count > 0)
        {
            yield return _openedMenus.Peek().Close();
        }

        _openedMenus.Push(menu);
        yield return menu.Open();
    }

    private IEnumerator BackToPreviousMenuRoutine()
    {
        yield return _openedMenus.Peek().Close();
        _openedMenus.Pop();
        yield return _openedMenus.Peek().Open();
    }
}
