using UnityEngine;

public interface IMovableTrap
{
    public Vector2 Move(Transform trap, WayPointsData wayPoints, float speed);
}