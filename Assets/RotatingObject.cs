using System.Collections;
using UnityEngine;
using Zenject;

public class RotatingObject : MonoBehaviour, IPauseable
{
    [SerializeField]
    private float _rotationSpeed;

    private LevelPauser _levelPauser;

    private Coroutine _rotationCoroutine;
    private bool _playedBeforePause;

    [Inject]
    public void Construct(LevelPauser levelPauser)
    {   
        _levelPauser = levelPauser;
        levelPauser.Subscribe(this);
    }

    public void Pause()
    {
        if (_rotationCoroutine != null)
        {
            StopCoroutine(_rotationCoroutine);
            _playedBeforePause = true;
        }
    }

    public void Unpause()
    {
        if (_playedBeforePause)
        {
            _rotationCoroutine = StartCoroutine(RotateRoutine());
            _playedBeforePause = false;
        }
    }

    private void Start()
    {
        _rotationCoroutine = StartCoroutine(RotateRoutine());
    }

    private IEnumerator RotateRoutine()
    {
        while (true)
        {
            var rotationAngle = (transform.rotation.eulerAngles.z +
                _rotationSpeed * Time.deltaTime) % 360;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));

            yield return null;
        }
    }

    private void OnDestroy()
    {
        _levelPauser.UnSubscribe(this);
    }
}
