using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LevelCompleteScrene : CompleteScrene
{
    [SerializeField]
    private LevelCompleteTimeUI _levelCompleteTimeUI;

    public override IEnumerator Open()
    {
        _levelCompleteTimeUI.ShowTime();
        return base.Open();
    }
}
