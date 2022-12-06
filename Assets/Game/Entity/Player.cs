using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDying
{
    [SerializeField] private EntityMovementData _setting;
    [SerializeField] private FreezeCircle _freezeCircle;
    [SerializeField] private float _abilityTakeDown;

    private Ability _currentAbility;
    private bool _gameStarted = false;
    public EntityMovement Movement { get; private set; }

    public event UnityAction Died;

    private void Start()
    {
        Movement = new EntityMovement(_setting);

        SetNewAblility(new TimeFreeze(2f, 0.03f, 0.1f, transform, _freezeCircle, _abilityTakeDown));
    }

    public void StartLevel()
    {
        _gameStarted = true;
        gameObject.SetActive(true);
    }

    public void Move(Vector2 direction)
    {
        if (_gameStarted)
            Movement.Move(direction);
    }

    public void SetNewAblility(Ability ability)
    {
        _currentAbility = ability;
    }

    public void UseAblility()
    {
        if (_currentAbility.AbleToAct && _gameStarted)
        {
            _currentAbility.Action();
            _currentAbility.AbleToAct = false;
            StartCoroutine(SetAbilityUseful(_currentAbility.TakeDownTime));
        }
    }

    private IEnumerator SetAbilityUseful(float delay)
    {
        yield return new WaitForSeconds(delay);
        _currentAbility.AbleToAct = true;
    }

    public void Die()
    {
        Died?.Invoke();
        _gameStarted = false;
        gameObject.SetActive(false);
    }
}