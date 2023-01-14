using Firebase.Analytics;
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
    private float _stopAcceleration;
    [SerializeField]
    private ParticleSystem _deathParticle;
    [SerializeField]
    private TrailRenderer _trailRenderer;
    [SerializeField]
    private GameObject _model;

    [SerializeField]
    private float _deathCameraShakeRadius;
    [SerializeField]
    private float _deathCameraShakeDuration;

    [SerializeField]
    private AudioClip _jumpSound;
    [SerializeField]
    private AudioClip _deathSound;

    private CameraShaker _cameraShaker;
    private Transform _startPosition;
    private Rigidbody2D _rigidbody;

    private Vector2 _previousVelocity = Vector2.zero;
    private float _gravityScale;

    private bool _isStoping;
    private bool _isDead;

    private AnalitycsFacade _analitycs;

    public event Action OnDie;

    public void Initialize(Transform startPosition, CameraShaker cameraShaker, AnalitycsFacade analitycs)
    {
        _startPosition = startPosition;
        _cameraShaker = cameraShaker;
        _analitycs = analitycs;

        _rigidbody = GetComponent<Rigidbody2D>();
        _gravityScale = _rigidbody.gravityScale;
    }

    public void EnableGravity()
    {
        _rigidbody.gravityScale = _gravityScale;
    }

    public void DisableGravity()
    {
        _rigidbody.gravityScale = 0;
    }

    public void Jump(Vector2 direction)
    {   
        _rigidbody.velocity = direction * _jumpForce;
        SoundsPlayer.Instance.Play(_jumpSound);
    }

    public void ResetToStartState()
    {
        _previousVelocity = Vector2.zero;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.simulated = true;

        _model.SetActive(true);
        transform.position = _startPosition.position;
        _trailRenderer.Clear();
    }

    public void Die()
    {
        _analitycs.LogPlayerDeath();
        OnDie?.Invoke();
    }

    public void Pause()
    {
        DisableMovement();
    }

    public void Unpause()
    {
        EnableMovement();
    }

    public IEnumerator PlayDeathAnimation()
    {
        SoundsPlayer.Instance.Play(_deathSound);
        _rigidbody.simulated = false;
        _model.SetActive(false);
        Instantiate(_deathParticle, transform.position, Quaternion.identity);
        _cameraShaker.Shake(_deathCameraShakeDuration, _deathCameraShakeRadius);
        yield return new WaitForSeconds(_deathCameraShakeDuration);
    }

    public IEnumerator SmoothStopRoutine()
    {
        yield return SmoothStopRoutine(_stopAcceleration);
    }

    public IEnumerator SmoothStopRoutine(float acceleration)
    {
        if (_isStoping)
        {
            yield break;
        }

        _isStoping = true;

        while (_rigidbody.velocity.sqrMagnitude != 0)
        {
            var accelerationVelocity = (-_rigidbody.velocity).normalized
                * acceleration * Time.fixedDeltaTime;

            _rigidbody.velocity += accelerationVelocity;

            if (_rigidbody.velocity.magnitude < 0.5)
            {
                _rigidbody.velocity = Vector2.zero;
            }

            yield return new WaitForFixedUpdate();
        }
        _isStoping = false;
    }

    private void DisableMovement()
    {
        _previousVelocity = _rigidbody.velocity;
        _rigidbody.velocity = Vector2.zero;
    }

    private void EnableMovement()
    {
        _rigidbody.velocity = _previousVelocity;
    }
}
