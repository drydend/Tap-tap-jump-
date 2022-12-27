using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameStarter : MonoBehaviour
{
    private Game _game;

    [Inject]
    public void Constuct(Game game)
    {
        _game = game;
        _game.StartGame();
    }
}
