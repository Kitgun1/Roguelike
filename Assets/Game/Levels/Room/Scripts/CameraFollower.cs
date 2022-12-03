using KiUtilities.Structures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private EntityFollowData _followData;

    private Rigidbody _body;
    private Vector3 _velocity = Vector3.zero;
    private float _multiplySpeed = 100;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        _body.useGravity = false;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 targetPosition = _followData.Target.position;
        Vector3 roomPosition = _level.CurrentRoom.transform.position;

        targetPosition.x = Mathf.Clamp(targetPosition.x, roomPosition.x + _followData.XPositionRange.min, roomPosition.x + _followData.XPositionRange.max);
        targetPosition.y = Mathf.Clamp(targetPosition.y, roomPosition.y + _followData.YPositionRange.min, roomPosition.y + _followData.YPositionRange.max);

        Vector3 targetVelocity = (targetPosition + _followData.Distance - transform.position) * _followData.SpeedMovementFollow * _multiplySpeed * Time.fixedDeltaTime;
        _body.velocity = Vector3.SmoothDamp(_body.velocity, targetVelocity, ref _velocity, _followData.SmoothSpeedMovement);
    }

    private void OnRoomChanged(Room room)
    {
        transform.SetParent(room.transform, true);
    }

    private void OnEnable()
    {
        _level.OnRoomChanged += OnRoomChanged;
    }

    private void OnDisable()
    {
        _level.OnRoomChanged -= OnRoomChanged;
    }
}

[System.Serializable]
public struct EntityFollowData
{
    public Transform Target;
    public Vector3 Distance;
    public float SpeedMovementFollow;
    public KiRangeFloat XPositionRange;
    public KiRangeFloat YPositionRange;
    [Range(0f, 0.1f)] public float SmoothSpeedMovement;
}