using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatedUIMenu : UIMenu
{
    private const string CloseAnimationName = "Closing";
    private const string OpenAnimationName = "Opening";

    [SerializeField]
    protected GameObject _menu;

    private Animator _animator;


    protected Animator Animator
    {
        get
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
            return _animator;
        }
    }
    public override IEnumerator Close()
    {
        IsAnimated = true;

        Animator.Play(CloseAnimationName);
        var clip = Animator.runtimeAnimatorController.animationClips
            .First(clip => clip.name == CloseAnimationName);
        
        yield return new WaitForSeconds(clip.length);
        _menu.SetActive(false);
        IsAnimated = false;
    }

    public override IEnumerator Open()
    {
        IsAnimated = true;

        _menu.SetActive(true);
        Animator.Play(OpenAnimationName);
        var clip = Animator.runtimeAnimatorController.animationClips
            .First(clip => clip.name == OpenAnimationName);

        yield return new WaitForSeconds(clip.length);

        IsAnimated = false;
    }
}
