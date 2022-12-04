using UnityEngine;

public interface IMovableTrap
{
    public Vector2 MoveTransform(Transform trap, WayPointsData wayPoints, float speed);
}