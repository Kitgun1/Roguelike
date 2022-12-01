using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreeze : Ability
{
    private float _actionTime;
    private float _startValue;

    public TimeFreeze(float actionTime, float startValue)
    {
        _actionTime = actionTime;
        _startValue = startValue;
    }

    public override void Action()
    {
        TimeScale.Set(_startValue);
        CouroutineStarter.Instance.StartCoroutine(ReturnTime());
    }

    private IEnumerator ReturnTime()
    {
        for (float i = _startValue; i < 1; i += 0.01f)
        {
            TimeScale.Set(i);
            yield return new WaitForSecondsRealtime(_actionTime / 50);
        }

        TimeScale.Set(1);
    }
}
