using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IDying
{
    [SerializeField] private EntityMovementData _setting;
    [SerializeField] private FreezeCircle _freezeCircle;
    [SerializeField] private float _abilityTakeDown;
    [SerializeField] private GameObject _playerVisible;
    [SerializeField] private Animator _animator;

    private Ability _currentAbility;
    private bool _gameStarted = false;

    public EntityMovement Movement { get; private set; }
    public EntityAnimation Animator { get; private set; }

    public event UnityAction Died;

    private void Start()
    {
        Movement = new EntityMovement(_setting);
        Animator = new EntityAnimation(_animator);

        SetNewAblility(new Dash(Movement, _setting.DashPower, _abilityTakeDown));
    }

    public void StartLevel()
    {
        _gameStarted = true;
        _playerVisible.SetActive(true);
    }

    public void Move(Vector2 direction)
    {
        if (_gameStarted)
            Movement.Move(direction);

        Animator.Animate(direction);
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

    public void TryDie()
    {
        if (Movement.State == MoveState.Moveing)
        {
            Died?.Invoke();
            _gameStarted = false;
            _playerVisible.SetActive(false);
        }
    }
}