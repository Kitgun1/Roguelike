using KiUtilities.Random;
using KiUtilities.Structures;
using UnityEngine;
using UnityEngine.Events;

public class Trap : ITrappable, IMovableTrap, ITurnableTrap, IPhysicalTrap
{
    private Vector2 _oldTargetPosition = Vector2.zero;
    private LayerMask _layerMask = 6;

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

    public void SetSettings(GameObject gameObject, TrapPhysicsPropertyData trapPhysicsPropertyData)
    {
        var rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0;
        rigidbody2D.sharedMaterial = trapPhysicsPropertyData.PhysicsMaterial2D;
    }

    public void StartDirectionImpuls(Rigidbody2D rigidbody2D, Vector2 direction)
    {
        rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
    }

    public void RandomImpuls(Rigidbody2D rigidbody2D, Vector2 direction)
    {
        rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
    }

    #endregion
}