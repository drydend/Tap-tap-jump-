﻿using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class NextLevelButton : MonoBehaviour
{
    private Game _game;

    [Inject]
    public void Construct(Game game)
    {
        _game = game;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(_game.StartNextLevel);
    }
}