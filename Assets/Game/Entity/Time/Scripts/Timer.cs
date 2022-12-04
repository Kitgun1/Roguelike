using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public event UnityAction<float> OnTick;

    private float _timeElapsed;

    public void StartCount()
    {
        _timeElapsed = 0;
        StartCoroutine(CountTime());
    }

    public void StopTimer()
    {
        StopCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            _timeElapsed += Time.deltaTime;
            OnTick?.Invoke(_timeElapsed);
        }
    }
}
