using System;
using UnityEngine;

[Serializable]
public struct GateData
{
    public ParticleSystem ParticleSystemEnter;
    public ParticleSystem ParticleSystemTeleport;
    public LayerMask LayerMask;
    public float DelayOpen;
}