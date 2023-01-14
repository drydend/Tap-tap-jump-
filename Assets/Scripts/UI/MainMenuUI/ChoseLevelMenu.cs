using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChoseLevelMenu : AnimatedUIMenu
{
    [SerializeField]
    private ScrollRect _scrollRect;
    [SerializeField]
    private RectTransform _contentTransform;

    [SerializeField]
    private PlayLevelButton _playLevelButtonPrefab;

    private LevelCompleateTimings _levelCompleateTimings;
    private Game _game;

    [Inject]
    public void Construct(Game game, ConfigDataProvider staticDataProvider)
    {
        _game = game;
        _levelCompleateTimings = staticDataProvider.LevelCompleteTimings;
    }

    public override IEnumerator Open()
    {
        yield return base.Open();
        _scrollRect.verticalNormalizedPosition = (_game.LastUnlockedLevel - 1) / (float)Game.LevelsNumber;
    }

    private void Start()
    {
        for (int i = Game.LevelsNumber; i > 0; i--)
        {
            var playLevelButton = Instantiate(_playLevelButtonPrefab, _contentTransform);
            var isTimeChallengeCompleated = _game.LevelsData[i].IsCompleated  
                && _levelCompleateTimings[i - 1] > _game.LevelsData[i].BestCompleteTime;
            playLevelButton.Initialize(_game, i, _game.LevelsData[i].IsUnlocked, isTimeChallengeCompleated);

            if (!_game.LevelsData[i].IsUnlocked)
            {
                playLevelButton.transform.localScale = new Vector3(0.6f, 0.6f, 1);
            }
        }
    }
}
