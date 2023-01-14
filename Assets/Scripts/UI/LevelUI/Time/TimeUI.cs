using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TimeUI : MonoBehaviour
{
    private const int MaxDecimalPlaces = 1;

    private TMP_Text _text;

    private TMP_Text Text
    {
        get
        {
            if(_text == null)
            {
                _text = GetComponent<TMP_Text>();
            }

            return _text;
        }
    }

    public void SetTime(float time)
    {
        int second = (int)time;
        int decimalPlaces = (int)((time - second) * Mathf.Pow(10, MaxDecimalPlaces ));

        Text.text = $"{second}.{decimalPlaces}";
    }
}