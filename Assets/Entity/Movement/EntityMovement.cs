using UnityEngine;

public class EntityMovement
{
    private EntityMovementData _data;

    private Vector3 _velocity = Vector3.zero;

    public EntityMovement(EntityMovementData data)
    {
        _data = data;
    }

    public void Movement(Vector2 direction)
    {
        Vector3 targetVelocity = new Vector3(direction.x, 0f, direction.y) * _data.MovementSpeed * Time.fixedDeltaTime;
        _data.Rigidbody.velocity = Vector3.SmoothDamp(_data.Rigidbody.velocity, targetVelocity, ref _velocity, _data.MovementSmooth);
    }

    public void Rotation(Transform transform, Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _data.RotationSpeed * Time.fixedDeltaTime);
            _data.Rigidbody.angularVelocity = Vector3.zero;
        }
    }
}

[System.Serializable]
public struct EntityMovementData
{
    [Header("Links")]
    public Rigidbody Rigidbody;

    [Header("Properties")]
    public float RotationSpeed;

    public float MovementSpeed;
    [Range(0f, 0.1f)] public float MovementSmooth;
}