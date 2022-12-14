using System;
using UnityEngine;

public class LevelWinTrigger : MonoBehaviour
{
    public event Action OnPlayerWin;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            OnPlayerWin?.Invoke();
        }   
    }
}