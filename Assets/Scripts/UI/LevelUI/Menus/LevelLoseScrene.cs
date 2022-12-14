using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LevelLoseScrene : LevelUI
{
    new public IEnumerator Open()
    {
        base.Open();
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorClipInfo(0).Length);
    }
}
