using UnityEngine;
using Zenject;

public class LevelCompleteTimingUI : MonoBehaviour
{
    [SerializeField]
    private TimeUI _timeUI;

    [Inject]
    public void Construct(Game game ,ConfigDataProvider dataProvider)
    {
        _timeUI.SetTime(dataProvider.LevelCompleteTimings[game.CurrentLevelNumber - 1]);
    }
}
