using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Text))]
public class LevelCounterUI : MonoBehaviour
{
    private TMP_Text _text;

    private Game _game;

    [Inject]
    public void Construct(Game game)
    {
        _game = game;

        _text = GetComponent<TMP_Text>();
        _text.text ="Level " + _game.CurrentLevelNumber.ToString();
    }
}
