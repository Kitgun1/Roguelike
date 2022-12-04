using NaughtyAttributes;
using System;

[Serializable]
public struct TrapPhysicsPropertyData
{
    public WayPointsData WayPoints;
    [MinValue(0f)] public float MoveSpeed;
    [MinValue(0f)] public float Radius;
}
