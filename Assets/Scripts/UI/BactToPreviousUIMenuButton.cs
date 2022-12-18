using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class BactToPreviousUIMenuButton : MonoBehaviour
{
    private UIMenuHandler _menuHandler;

    [Inject]
    public void Construct(UIMenuHandler menuHancler)
    {
        _menuHandler = menuHancler;
        GetComponent<Button>().onClick.AddListener(_menuHandler.BackToPreviousMenu);
    }
}
