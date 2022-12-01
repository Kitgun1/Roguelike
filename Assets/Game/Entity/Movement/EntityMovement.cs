using UnityEngine;

public class EntityMovement : IMove
{
    private EntityMovementData _data;

    private Vector2 _velocity = Vector2.zero;

    public EntityMovement(EntityMovementData data)
    {
        _data = data;
    }

    public void Move(Vector2 direction)
    {
        Vector2 targetVelocity = new Vector2(direction.x, direction.y) * _data.MovementSpeed * Time.fixedDeltaTime;

        _data.Rigidbody.velocity = Vector2.ClampMagnitude((Vector2.SmoothDamp(_data.Rigidbody.velocity, targetVelocity, ref _velocity, _data.MovementSmooth)), _data.MaxSpeed);
    }
}

[System.Serializable]
public struct EntityMovementData
{
    [Header("Links")]
    public Rigidbody2D Rigidbody;

    public float MovementSpeed;
    public float MaxSpeed;
    [Range(0f, 0.1f)] public float MovementSmooth;
}