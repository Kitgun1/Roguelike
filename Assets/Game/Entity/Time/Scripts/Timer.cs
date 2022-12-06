using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public event UnityAction<float> OnTick;

    private float _timeElapsed;
    private bool _working;

    public void StartCount()
    {
        _timeElapsed = 0;
        _working = true;
        StartCoroutine(CountTime());
    }

    public void StopTimer()
    {
        _working = false;
    }

    private IEnumerator CountTime()
    {
        while (_working)
        {
            _timeElapsed += Time.deltaTime;
            OnTick?.Invoke(_timeElapsed);
            yield return new WaitForEndOfFrame();
        }
    }
}
