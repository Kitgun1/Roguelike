using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EntityMovementData _setting;

    private EntityMovement _movement;

    private void Start()
    {
        _movement = new EntityMovement(_setting);
    }

    public void Move(Vector2 direction)
    {
        _movement.Move(direction);
    }
}