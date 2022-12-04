using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trap : ITrappable, IMovableTrap, ITurnableTrap, IPhysicalTrap
{
    private Vector2 _oldTargetPosition = Vector2.zero;
    private LayerMask _layerMask = 6;
    private List<Vector2> _wayPoints = new List<Vector2>();

    public event UnityAction OnDestroy;
    public event UnityAction<int, int> OnApplyDamage;

    #region ITrappable

    public void Destroy(GameObject gameObject)
    {
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }

    public bool TryDamage(int damageValue)
    {
        int healthRemaind = 0;

        OnApplyDamage?.Invoke(damageValue, healthRemaind);
        return true;
    }

    #endregion

    #region IMovableTrap

    public Vector2 MoveTransform(Transform trap, WayPointsData wayPoints, float speed)
    {
        Vector2 targetPoint;
        if (trap.position == wayPoints.StartPoint.position)
            targetPoint = wayPoints.EndPoint.position;
        else if (trap.position == wayPoints.EndPoint.position)
            targetPoint = wayPoints.StartPoint.position;
        else
            targetPoint = _oldTargetPosition;

        _oldTargetPosition = targetPoint;
        return Vector2.MoveTowards(trap.position, targetPoint, speed);
    }

    #endregion

    #region ITurnableTrap

    public Quaternion Turn(Transform trap, TurnType turnType, float speed)
    {
        Quaternion rotation = trap.rotation;
        rotation.eulerAngles += new Vector3(0f, 0f, (int)turnType * speed);
        return rotation;
    }

    #endregion

    #region IPhysicalTrap

    public Vector2 MovePhysics(Transform trap, WayPointsData wayPoints, float speed, out WayPointsData newWayPoints)
    {
        Vector2 targetPoint;

        if (trap.position == wayPoints.StartPoint.position)
        {
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
        for (int i = 0; i < 2; ++i)
        {
            if (hit && i == 0)
            {
                position = hit.point + hit.normal * 0.00001f;
                direction = Vector2.Reflect(direction, hit.normal);
            }
            else
            {
                wayPoints.EndPoint.position = hit.point;
                wayPoints.StartPoint.position = position;
                Debug.Log($"{position} ~!~ {hit.point}");
            }
        }
        //Debug.Log($"{wayPoints.StartPoint.position} ~ {wayPoints.EndPoint.position}");
        return wayPoints;
    }

    #endregion
}