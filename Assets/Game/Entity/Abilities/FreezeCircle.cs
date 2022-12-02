using System.Collections;
using UnityEngine;

public class FreezeCircle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _tickTime;
    [SerializeField] private float _maxSize;
    [SerializeField] private float _grothSpeed;

    [field: SerializeField] public float Radius { get; private set; }

    public void StartShowCircle() => StartCoroutine(ShowCircle());
    public void StopShowCircle() => StopCoroutine(ShowCircle());

    private IEnumerator ShowCircle()
    {
        _sprite.enabled = true;

        while (true)
        {
            UpdateRadius();
            yield return new WaitForEndOfFrame();
        }
    }


    private void UpdateRadius()
    {
        transform.localScale = Vector3.one * TimeScale.Value * 10;
    }
}
