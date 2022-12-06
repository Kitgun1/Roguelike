using NaughtyAttributes;
using System;
using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using KiUtilities.Structures;

[Serializable]
public struct TrapPhysicsPropertyData
{
    public PhysicsMaterial2D PhysicsMaterial2D;
    public int RangePowerImpuls;
    [MinValue(0f)] public float MoveSpeed;
}
