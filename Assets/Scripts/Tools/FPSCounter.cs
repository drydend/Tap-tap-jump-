using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _fpsCounter;
    [SerializeField]
    private TMP_Text _targetFR;
    [SerializeField]
    private float _updateStep = 0.1f;
    private float _currentTime;

    void Update()
    {
        if (_currentTime > _updateStep)
        {
            _fpsCounter.text = ((int)(1 / Time.deltaTime)).ToString();
            _currentTime %= _updateStep;
        }
        else
        {
            _currentTime += Time.deltaTime;
        }

        _targetFR.text = Application.targetFrameRate.ToString();
    }
}
