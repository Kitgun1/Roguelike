using NaughtyAttributes;
using System;
using UnityEngine;

[Serializable]
public struct GateData
{
    public ParticleSystem ParticleSystemEnter;
    public ParticleSystem ParticleSystemTeleport;
    [Layer] public int Layer;
    public float DelayOpen;
}