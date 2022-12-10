using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]  
public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _isMovementEnable;
    private Vector2 _previousVelocity = Vector2.zero;

    public event Action OnDie;

    private void Awake()
    {   
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
    }

    public void EnableMovement()
    {
        _rigidbody.simulated = true;
        _rigidbody.velocity = _previousVelocity;
        _isMovementEnable = true;
    }

    public void DisableMovement()
    {
        _previousVelocity = _rigidbody.velocity;
        _rigidbody.simulated = false;
        _isMovementEnable = false;
    }

    public void SetVelocity(Vector2 velocity)
    {
        if (!_isMovementEnable)
        {
            return;
        }

        _rigidbody.gravityScale = 2;
        _rigidbody.velocity = velocity;
    }

    public void Die()
    {
        OnDie?.Invoke();
    }

    public IEnumerator PlayDeathAnimation()
    {
        yield break;
    }
}
