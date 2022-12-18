using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void LoadSceneAsInitial(string sceneName)
    {
        Coroutines.StartRoutine(LoadInitialLevelRoutine(sceneName));
    }

    public void LoadScene(string sceneName)
    {
        Coroutines.StartRoutine(LoadLevelRoutine(sceneName));
    }

    private IEnumerator LoadInitialLevelRoutine(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        yield return SceneTransition.Instance.InAnimationRoutine();
    }

    private IEnumerator LoadLevelRoutine(string sceneName)
    {
        yield return SceneTransition.Instance.OutAnimationRoutine();

        yield return SceneManager.LoadSceneAsync(sceneName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        yield return SceneTransition.Instance.InAnimationRoutine();
    }
}
