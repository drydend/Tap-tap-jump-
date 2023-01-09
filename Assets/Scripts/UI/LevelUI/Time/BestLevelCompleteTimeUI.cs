using UnityEngine;

public class BestLevelCompleteTimeUI : MonoBehaviour
{
    [SerializeField]
    private Level _level;
    [SerializeField]
    private TimeUI _timeUI;

    private void Awake()
    {
        _level.OnComplete += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _timeUI.SetTime(_level.BestCompleteTime);
    }
}
