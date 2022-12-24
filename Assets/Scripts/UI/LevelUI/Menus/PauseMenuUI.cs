using System.Collections;
using UnityEngine;

public class PauseMenuUI : AnimatedUIMenu
{
    new public IEnumerator Close()
    {
        base.Close();
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorClipInfo(0).Length);
    }
}