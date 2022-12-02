using System.Collections;
using UnityEngine;

public class TimeFreeze : Ability
{
    private float _actionTime;
    private float _startValue;
    private FreezeCircle _freezeCircle;

    public TimeFreeze(float actionTime, float startValue, FreezeCircle circle)
    {
        _actionTime = actionTime;
        _startValue = startValue;
        _freezeCircle = circle;
    }

    public override void Action()
    {
        TimeScale.Set(_startValue);
        _freezeCircle.StartShowCircle();
        CouroutineStarter.Instance.StartCoroutine(ReturnTime());
    }

    private IEnumerator ReturnTime()
    {
        for (float i = _startValue; i < 1; i += 0.01f)
        {
            TimeScale.Set(i);

            yield return new WaitForSecondsRealtime(_actionTime / 100);
        }
        TimeScale.Set(1);
        _freezeCircle.StopShowCircle();
    }
}
