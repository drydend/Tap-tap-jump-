using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayLevelButton : MonoBehaviour, IInteractableUI
{
    [SerializeField]
    private List<Image> _timeChallengeBeatedSign;

    [SerializeField]
    private Image _lockImage;

    [SerializeField]
    private TMP_Text _text;

    private Game _game;
    private int _levelNumber;
    private bool _isUnlocked;
    private bool _isTimeChallengeBeated;

    public event Action OnPlayerInteracted;

    public void Initialize(Game game, int levelNumber, bool isUnlocked, bool isTimeChallangeBeated)
    {
        _game = game;
        _levelNumber = levelNumber;
        _isUnlocked = isUnlocked;
        _isTimeChallengeBeated = isTimeChallangeBeated;
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

        SetEnableChallengeBeatSign(_isTimeChallengeBeated);
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

    private void SetEnableChallengeBeatSign(bool value)
    {
        foreach (var item in _timeChallengeBeatedSign)
        {
            item.enabled = value;
        }
    }
}
