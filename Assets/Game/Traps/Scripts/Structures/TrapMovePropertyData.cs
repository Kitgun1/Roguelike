using NaughtyAttributes;
using System;

[Serializable]
public struct TrapMovePropertyData
{
    public WayPointsData WayPoints;
    [MinValue(0f)] public float MoveSpeed;
}