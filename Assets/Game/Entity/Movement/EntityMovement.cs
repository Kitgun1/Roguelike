using System.Collections;
using UnityEngine;

public class EntityMovement : IMove
{
    public MoveState State => _state;

    private EntityMovementData _data;

    private Vector2 _velocity = Vector2.zero;
    private Vector2 _currentDirection;
    private MoveState _state;

    public EntityMovement(EntityMovementData data)
    {
        _data = data;
        _state = MoveState.Moveing;
    }

    public void Move(Vector2 direction)
    {
        if (_state != MoveState.Moveing)
            return;

        Vector2 targetVelocity = new Vector2(direction.x, direction.y) * _data.MovementSpeed * Time.deltaTime;
        _data.Rigidbody.velocity = Vector2.ClampMagnitude(Vector2.SmoothDamp(_data.Rigidbody.velocity, targetVelocity, ref _velocity, _data.MovementSmooth), _data.MaxSpeed);

        if (direction != Vector2.zero)
            _currentDirection = direction;
    }

    public void Dash(float power)
    {
        _currentDirection.Normalize();
        _data.Rigidbody.AddForce(_currentDirection * power);
        _state = MoveState.Dashing;
    }

    public IEnumerator ReturnToMove()
    {
        yield return new WaitForSeconds(_data.DashTime);
        _state = MoveState.Moveing;
    }
}

[System.Serializable]
public struct EntityMovementData
{
    [Header("Links")]
    public Rigidbody2D Rigidbody;

    public float MovementSpeed;
    public float MaxSpeed;
    public float DashPower;
    public float DashTime;
    [Range(0f, 0.1f)] public float MovementSmooth;
}

public enum MoveState
{
    Dashing,
    Moveing
}