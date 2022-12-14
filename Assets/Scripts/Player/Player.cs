using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]  
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private ParticleSystem _deathParticle;

    private Transform _startPosition;
    private Rigidbody2D _rigidbody;
    private bool _isMovementEnable;
    private Vector2 _previousVelocity = Vector2.zero;

    public event Action OnDie;

    public void Initialize(Transform startPosition)
    {
        _startPosition = startPosition;
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

    public void Jump(Vector2 direction)
    {
        if (!_isMovementEnable)
        {
            return;
        }

        _rigidbody.velocity = direction * _jumpForce;
    }
    public void ResetToStartPosition()
    {
        gameObject.SetActive(false);
        transform.position = _startPosition.position;
        gameObject.SetActive(true);
    }

    public void Die()
    {
        OnDie?.Invoke();
    }

    public IEnumerator PlayDeathAnimation()
    {
        yield break;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

}
