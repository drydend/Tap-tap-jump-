using System.Collections;
using UnityEngine;

public class LevelUI : UIMenu
{
    private const string CloseAnimationName = "Closing";
    private const string OpenAnimationName = "Opening";

    [SerializeField]
    protected GameObject _menu;

    private Coroutine _animationCoroutine;
    private Animator _animator;
    protected Animator Animator 
    {
        get
        {
            if(_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
            return _animator;
        }
    }

    public override void Close()
    {   
        if(_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
        }

        _animationCoroutine = StartCoroutine(CloseRoutine());
    }

    public override void Open()
    {
        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
        }

        _menu.SetActive(true);
        _animationCoroutine = StartCoroutine(OpenRoutine());
    }

    private IEnumerator CloseRoutine()
    {
        Animator.Play(CloseAnimationName);
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorClipInfo(0).Length);
        _menu.SetActive(false);
    }

    private IEnumerator OpenRoutine()
    {
        Animator.Play(OpenAnimationName);
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorClipInfo(0).Length);
    }
}
