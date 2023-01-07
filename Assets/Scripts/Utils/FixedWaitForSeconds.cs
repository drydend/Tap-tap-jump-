using UnityEngine;
public class FixedWaitForSeconds : CustomYieldInstruction
{
    private float _currentTime;
    private float _timeToWait;
    private FloatWrapped _overTime;

    public FixedWaitForSeconds(float time, FloatWrapped overTime)
    {
        _currentTime = 0;
        _timeToWait = time;
        _overTime = overTime;
    }

    public override bool keepWaiting
    {
        get
        {   
            if(_currentTime >= _timeToWait)
            {
                _overTime.Value += _currentTime - _timeToWait;
                _overTime = null;
                return false;
            }

            _currentTime += Time.deltaTime;

            return true;
        }
    }
}
