using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour
{
    [SerializeField]
    private Level _level;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(_level.RestartLevel);
    }
}
