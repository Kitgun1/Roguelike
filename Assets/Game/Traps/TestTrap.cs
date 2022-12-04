using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class TestTrap : MonoBehaviour
{
    [SerializeField] private WayPointsData _wayPoints;

    private List<Vector2> _points = new List<Vector2>();
    private Vector2 _oldTargetPosition;

    private List<RaycastHit2D> _hits = new List<RaycastHit2D>();

    private void Update()
    {
        transform.position = MovePhysics(transform, _wayPoints, 1, out _wayPoints);
    }

    public Vector2 MovePhysics(Transform trap, WayPointsData wayPoints, float speed, out WayPointsData newWayPoints)
    {
        Vector2 targetPoint;

        if (trap.position == wayPoints.StartPoint.position)
        {
            _points.Clear();
            newWayPoints = wayPoints;
            targetPoint = wayPoints.EndPoint.position;
        }
        else if (trap.position == wayPoints.EndPoint.position)
        {
            newWayPoints = GetNewWayPoints(trap.position, wayPoints);

            targetPoint = wayPoints.EndPoint.position;
        }
        else
        {
            newWayPoints = wayPoints;
            targetPoint = _oldTargetPosition;
        }

        _oldTargetPosition = targetPoint;
        Vector2 newPosition = Vector2.MoveTowards(trap.position, targetPoint, speed);
        return newPosition;
    }

    public WayPointsData GetNewWayPoints(Vector3 currentPosition, WayPointsData wayPoints)
    {
        //wayPoints.EndPoint.position = Physics2D.CircleCast(wayPoints.StartPoint.position, radius, (Vector2)wayPoints.StartPoint.position + direction, Mathf.Infinity, _layerMask).point;

        Vector2 position = currentPosition;
        Vector2 direction = wayPoints.EndPoint.position - currentPosition;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, 20);
        for (int i = 0; i < 3; ++i)
        {
            if (hit)
            {
                position = hit.point + hit.normal * 0.00001f;
                direction = Vector2.Reflect(direction, hit.normal);

                wayPoints.EndPoint.position = hit.point;
                wayPoints.StartPoint.position = position;
                _points.Add(position);
                _points.Add(hit.point);
            }
        }
        return wayPoints;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < _points.Count - 1; i++)
        {
            Debug.DrawLine(_points[i], _points[i + 1], Color.red);
        }
    }
}