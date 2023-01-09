using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private float _inAnimationDuration;
    [SerializeField]
    private float _outAnimationDuration;
    [SerializeField]
    private Image _fadeScrene;

    public static SceneTransition Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public IEnumerator InAnimationRoutine()
    {
        _fadeScrene.enabled = true;

        float timeElapsedNormalized = 1f;

        _fadeScrene.color = new Color(_fadeScrene.color.r, _fadeScrene.color.g,
                _fadeScrene.color.b, 1f);

        while (timeElapsedNormalized > 0)
        {
            timeElapsedNormalized -= Time.unscaledDeltaTime / _inAnimationDuration;

            float alpha = Mathf.Clamp(timeElapsedNormalized, 0f, 1f);

            _fadeScrene.color = new Color(_fadeScrene.color.r, _fadeScrene.color.g,
                _fadeScrene.color.b, alpha);

            yield return null;
        }

        _fadeScrene.enabled = false;
    }
    public IEnumerator OutAnimationRoutine()
    {
        _fadeScrene.enabled = true;

        float timeElapsedNormalized = 0f;

        _fadeScrene.color = new Color(_fadeScrene.color.r, _fadeScrene.color.g,
                _fadeScrene.color.b, 0f);

        while (timeElapsedNormalized < 1)
        {
            timeElapsedNormalized += Time.unscaledDeltaTime / _outAnimationDuration;

            float alpha = Mathf.Clamp(timeElapsedNormalized, 0f, 1f);

            _fadeScrene.color = new Color(_fadeScrene.color.r, _fadeScrene.color.g,
                _fadeScrene.color.b, alpha);

            yield return null;
        }
    }
}
