using UnityEngine;

public interface IPhysicalTrap
{
    public Vector2 MovePhysics(Transform trap, WayPointsData wayPoints, float speed, out WayPointsData newWayPoints);
    public WayPointsData GetNewWayPoints(Vector3 currentPosition, WayPointsData wayPoints);
}
