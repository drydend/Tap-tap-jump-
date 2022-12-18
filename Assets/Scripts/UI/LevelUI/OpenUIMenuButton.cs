using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class OpenUIMenuButton : MonoBehaviour
{
    [SerializeField]
    private UIMenu _menu;

    private UIMenuHandler _menuHandler;

    [Inject]
    public void Construct(UIMenuHandler menuHancler)
    {
        _menuHandler = menuHancler;
        GetComponent<Button>().onClick.AddListener(OpenMenu);
    }

    private void OpenMenu()
    {
        _menuHandler.OpenMenu(_menu);
    }
}
