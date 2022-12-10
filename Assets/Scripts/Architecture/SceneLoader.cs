using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void LoadInitialLevel(string levelName)
    {
        Coroutines.StartRoutine(LoadInitialLevelRoutine(levelName));
    }

    public void LoadLevel(string levelName)
    {
        Coroutines.StartRoutine(LoadLevelRoutine(levelName));
    }

    private IEnumerator LoadInitialLevelRoutine(string levelName)
    {
        yield return SceneManager.LoadSceneAsync(levelName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelName));

        yield return SceneTransition.Instance.InAnimationRoutine();
    }

    private IEnumerator LoadLevelRoutine(string levelName)
    {
        yield return SceneTransition.Instance.OutAnimationRoutine();

        yield return SceneManager.LoadSceneAsync(levelName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelName));

        yield return SceneTransition.Instance.InAnimationRoutine();
    }
}
