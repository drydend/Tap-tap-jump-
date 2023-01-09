using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{   
    public bool IsLoading { get; private set; }
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
        IsLoading = true;

        yield return SceneManager.LoadSceneAsync(sceneName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        IsLoading = false;

        yield return SceneTransition.Instance.InAnimationRoutine();
    }

    private IEnumerator LoadLevelRoutine(string sceneName)
    {
        yield return SceneTransition.Instance.OutAnimationRoutine();

        IsLoading = true;

        yield return SceneManager.LoadSceneAsync(sceneName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));

        IsLoading = false;

        yield return SceneTransition.Instance.InAnimationRoutine();
    }
}
