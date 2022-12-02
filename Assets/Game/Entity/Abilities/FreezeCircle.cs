using System.Collections;
using UnityEngine;

public class FreezeCircle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private float _tickTime;
    [SerializeField] private float _maxSize;
    [SerializeField] private float _grothTime;
    [SerializeField] private float _destroyTime;

    [field: SerializeField] public float Radius { get; private set; }

    public void Grew()
    {
        StartCoroutine(ChangeSize(_maxSize));
    }

    public void Decrease()
    {
        StopCoroutine(ChangeSize(_maxSize));
        StartCoroutine(ChangeSize(0));
        Destroy(gameObject, _destroyTime);
    }

    private IEnumerator ChangeSize(float targetSize)
    {
        float currentSize = transform.localScale.x;

        while (currentSize != targetSize)
        {
            currentSize = Mathf.SmoothStep(currentSize, targetSize, _grothTime);
            transform.localScale = Vector3.one * currentSize;
            yield return new WaitForFixedUpdate();
        }

    }
}
