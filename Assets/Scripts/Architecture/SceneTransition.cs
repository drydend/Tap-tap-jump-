using System.Collections;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator InAnimationRoutine()
    {
        yield break;
    }
    public IEnumerator OutAnimationRoutine()
    {
        yield break;
    }
}
