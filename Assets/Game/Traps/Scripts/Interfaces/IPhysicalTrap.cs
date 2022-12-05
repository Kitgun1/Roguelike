using KiUtilities.Structures;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysicalTrap
{
    public void SetSettings(GameObject gameObject, TrapPhysicsPropertyData trapPhysicsPropertyData);

    public void StartDirectionImpuls(Rigidbody2D rigidbody2D, KiRangeInt rangePower);
}
