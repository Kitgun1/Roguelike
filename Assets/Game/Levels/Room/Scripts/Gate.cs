using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour, IGate
{
    [SerializeField] private GateData _gateProperty;

    private IEnumerator _gateEnumerator = null;
    private Transform _player;

    public event UnityAction OnEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_gateEnumerator != null && collision.gameObject.layer == 7) return;

        _player = collision.transform;
        _gateEnumerator = OpenGate(_gateProperty.DelayOpen, _player);
        StartCoroutine(_gateEnumerator);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_gateEnumerator != null && collision.gameObject.layer == 7) return;

        _player = null;
        StopCoroutine(_gateEnumerator);
    }

    private IEnumerator OpenGate(float timeToOpen, Transform player)
    {
        _gateProperty.ParticleSystemEnter.Play();
        yield return new WaitForSeconds(timeToOpen);
        OnEnter?.Invoke();
        Instantiate(_gateProperty.ParticleSystemTeleport, player);
        _gateProperty.ParticleSystemEnter.Stop();
        _gateEnumerator = null;
    }
}