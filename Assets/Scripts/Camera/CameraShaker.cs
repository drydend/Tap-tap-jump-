using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private Coroutine _shakeCoroutine;

    public void Shake(float duration, float radius)
    {
        if(_shakeCoroutine != null)
        {
            StopCoroutine(_shakeCoroutine);
            _camera.transform.localPosition = Vector3.zero;
        }

        _shakeCoroutine =  StartCoroutine(ShakeRoutine(duration, radius));
    }

    private IEnumerator ShakeRoutine(float duration, float radius)
    {
        float timeElapsedNormilized = 0f;

        while(timeElapsedNormilized < 1)
        {
            Vector2 offset = Random.insideUnitCircle * radius;
            _camera.transform.localPosition = (Vector3) offset;

            timeElapsedNormilized += Time.deltaTime / duration;
            yield return null;
        }

        _camera.transform.localPosition = Vector3.zero;
    }

}
