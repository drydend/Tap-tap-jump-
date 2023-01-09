using System;
using UnityEngine;

public class LevelWinTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip _triggerSound;

    public event Action OnPlayerWin;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            SoundsPlayer.Instance.Play(_triggerSound);
            OnPlayerWin?.Invoke();
        }   
    }
}