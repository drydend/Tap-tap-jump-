using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class BactToPreviousUIMenuButton : MonoBehaviour, IInteractableUI
{
    private UIMenuHandler _menuHandler;

    public event Action OnPlayerInteracted;

    [Inject]
    public void Construct(UIMenuHandler menuHancler)
    {
        _menuHandler = menuHancler;
        GetComponent<Button>().onClick.AddListener(BackToPreviousMenu);
    }

    private void BackToPreviousMenu()
    {
        OnPlayerInteracted?.Invoke();
        _menuHandler.BackToPreviousMenu();
    }
}
