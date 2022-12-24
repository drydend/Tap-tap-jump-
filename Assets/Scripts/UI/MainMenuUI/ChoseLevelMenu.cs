using System.Collections;
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

    private Game _game;

    [Inject]
    public void Construct(Game game)
    {
        _game = game;
    }

    public override IEnumerator Open()
    {
        yield return base.Open();
        _scrollRect.verticalNormalizedPosition = (_game.LastUnlockedLevel - 1) / (float)Game.LevelsNumber;
    }

    private void Awake()
    {
        for (int i = Game.LevelsNumber; i > 0; i--)
        {
            var playLevelButton = Instantiate(_playLevelButtonPrefab, _contentTransform);
            playLevelButton.Initialize(_game, i, _game.LevelsData[i].IsUnlocked);

            if (!_game.LevelsData[i].IsUnlocked)
            {
                playLevelButton.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
        }
    }
}
