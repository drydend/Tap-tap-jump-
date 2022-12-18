using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChoseLevelMenu : UIMenu
{
    [SerializeField]
    private GameObject _menu;

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

    public override void Close()
    {
        _menu.SetActive(false);
    }

    public override void Open()
    {
        _menu.SetActive(true);
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
