using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EntityMovementData _setting;

    private Ability _currentAbility;
    public EntityMovement Movement { get; private set; }

    private void Start()
    {
        Movement = new EntityMovement(_setting);

        SetNewAblility(new TimeFreeze(1f, 0f));
    }

    public void Move(Vector2 direction)
    {
        Movement.Move(direction);
    }

    public void SetNewAblility(Ability ability)
    {
        _currentAbility = ability;
    }

    public void UseAblility()
    {
        _currentAbility.Action();
    }
}