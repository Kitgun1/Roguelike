using NaughtyAttributes;
using System;

[Serializable]
public struct TrapTurnPropertyData
{
    public TurnType TurnType;
    [MinValue(0f)] public float EularSpeed;
}