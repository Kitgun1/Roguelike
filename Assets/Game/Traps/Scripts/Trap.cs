using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class Trap : ITrappable, IMovableTrap, ITurnableTrap
{
    private Vector2 _oldTargetPosition = Vector2.zero;

    public event UnityAction OnDestroy;
    public event UnityAction<int, int> OnApplyDamage;

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

    public Vector2 Move(Transform trap, WayPointsData wayPoints, float speed)
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

    public Quaternion Turn(Transform trap, TurnType turnType, float speed)
    {
        Quaternion rotation = trap.rotation;
        rotation.eulerAngles += new Vector3(0f, 0f, (int)turnType * speed);
        return rotation;
    }
}