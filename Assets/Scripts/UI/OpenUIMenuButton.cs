using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class OpenUIMenuButton : MonoBehaviour, IInteractableUI

{
    [SerializeField]
    private UIMenu _menu;

    private UIMenuHandler _menuHandler;

    public event Action OnPlayerInteracted;

    [Inject]
    public void Construct(UIMenuHandler menuHancler)
    {
        _menuHandler = menuHancler;
        GetComponent<Button>().onClick.AddListener(OpenMenu);
    }

    private void OpenMenu()
    {   
        OnPlayerInteracted?.Invoke();
        _menuHandler.OpenMenu(_menu);
    }
}
