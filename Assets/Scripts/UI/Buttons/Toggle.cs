using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Toggle : MonoBehaviour, IPointerDownHandler, IInteractableUI
{
    [SerializeField]
    private Sprite _onSprite;
    [SerializeField]
    private Sprite _offSprite;
    [Space][SerializeField]
    private Image _targetImage;

    public bool IsOn { get; private set;}
    public event Action OnValueChanged;
    public event Action OnPlayerInteracted;

    public void SetValue(bool value)
    {
        IsOn = value;
        UpdateUI();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        InverseToggleValue();
    }

    private void InverseToggleValue()
    {
        IsOn = !IsOn;
        OnValueChanged?.Invoke();
        OnPlayerInteracted?.Invoke();
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        if (IsOn)
        {
            _targetImage.sprite = _onSprite;
        }
        else
        {
            _targetImage.sprite = _offSprite;
        }
    }
}
