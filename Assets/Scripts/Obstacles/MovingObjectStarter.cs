using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectStarter : MonoBehaviour
{
    private List<MovingObject> _movingObjects = new List<MovingObject>();

    public void Subscribe(MovingObject movingObject)
    {
        _movingObjects.Add(movingObject);
    }

    public void UnSubscribe(MovingObject movingObject)
    {
        _movingObjects.Remove(movingObject);
    }

    private void Start()
    {
        StartCoroutine(StartRoutine());
    }

    private IEnumerator StartRoutine() 
    {
        yield return new WaitForSeconds(0f);
        foreach (var item in _movingObjects)
        {
            item.StartMoving();
        }
    }
}