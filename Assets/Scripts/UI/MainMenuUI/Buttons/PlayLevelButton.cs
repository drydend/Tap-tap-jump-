using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayLevelButton : MonoBehaviour, IInteractableUI
{
    [SerializeField]
    private Image _lockImage;
    [SerializeField]
    private TMP_Text _text;

    private Game _game;
    private int _levelNumber;
    private bool _isUnlocked;

    public event Action OnPlayerInteracted;

    public void Initialize(Game game, int levelNumber, bool isUnlocked)
    {
        _game = game;
        _levelNumber = levelNumber; 
        _isUnlocked = isUnlocked;
        GetComponent<Button>().onClick.AddListener(PlayLevel);


        _text.text = _levelNumber.ToString();

        if (isUnlocked)
        {   
            _lockImage.gameObject.SetActive(false);
            _text.gameObject.SetActive(true);
        }
        else
        {
            _lockImage.gameObject.SetActive(true);
            _text.gameObject.SetActive(false);
        }

    }

    private void PlayLevel()
    {
        if (!_isUnlocked)
        {
            return;
        }

        OnPlayerInteracted?.Invoke();
        _game.PlayLevel(_levelNumber);
    }
}
