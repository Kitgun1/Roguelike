using System.Collections;
using UnityEngine;

public class TimeFreeze : Ability
{
    private float _actionTime;
    private float _startValue;
    private float _changeDelta;
    private FreezeCircle _freezeCircleTemplate;
    private FreezeCircle _freezeCircle;
    private Transform _parent;

    public TimeFreeze(float actionTime, float changeDelta, float startValue, Transform parent, FreezeCircle circle, float takeDown) : base(takeDown)
    {
        _actionTime = actionTime;
        _startValue = startValue;
        _changeDelta = changeDelta;
        _freezeCircleTemplate = circle;
        _parent = parent;
    }

    public override void Action()
    {
        TimeScale.Set(Time.timeScale);
        _freezeCircle = Object.Instantiate(_freezeCircleTemplate, _parent.position, Quaternion.identity);

        CouroutineStarter.Instance.StartCoroutine(FreezeTime());
        CouroutineStarter.Instance.StartCoroutine(ReturnTime());
    }

    private IEnumerator FreezeTime()
    {
        _freezeCircle.Grew();
        while (TimeScale.Value > _startValue)
        {
            TimeScale.Set(Mathf.MoveTowards(TimeScale.Value, _startValue, _changeDelta));
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator ReturnTime()
    {
        yield return new WaitForSeconds(_actionTime);

        _freezeCircle.Decrease();
        while (TimeScale.Value < 1)
        {
            TimeScale.Set(Mathf.MoveTowards(TimeScale.Value, 1, _changeDelta));

            yield return new WaitForFixedUpdate();
        }
    }
}