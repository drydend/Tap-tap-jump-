using UnityEngine;

public class UIInteractionSoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip _interationSound;

    private void Awake()
    {

        GetComponent<IInteractableUI>().OnPlayerInteracted += PlaySound;
    }

    private void PlaySound()
    {
        SoundsPlayer.Instance.Play(_interationSound);
    }
}
