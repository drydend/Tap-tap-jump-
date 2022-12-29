using System.Collections;
using UnityEngine;
using Zenject;

public class InverseOfControlImage : MonoBehaviour
{
    [SerializeField]
    private bool _facingRight;

    private RectTransform _rectTransform;

    private Settings _settings;

    [Inject]
    public void Construct(Settings settings)
    {
        _rectTransform = GetComponent<RectTransform>();
        _settings = settings;
        _settings.IsControlInvertedChanged += InverseImage;
        Initialize();
    }

    private void InverseImage()
    {
        _rectTransform.localScale = new Vector2(_rectTransform.localScale.x *
            -1, _rectTransform.localScale.y);
    }

    private void Initialize()
    {
        _rectTransform.localScale = new Vector2(_rectTransform.localScale.x * _facingRight.ToInt()
            , _rectTransform.localScale.y);
    }

    private void OnDestroy()
    {
        _settings.IsControlInvertedChanged -= InverseImage;
    }
}
