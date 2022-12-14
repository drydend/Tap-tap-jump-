using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class UnpauseButton : MonoBehaviour
{
    private LevelPauser _levelPauser;

    [Inject]
    public void Construct(LevelPauser levelPauser)
    {
        _levelPauser = levelPauser;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(_levelPauser.Unpause);
    }
}
