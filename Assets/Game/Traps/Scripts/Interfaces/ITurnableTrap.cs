using UnityEngine;

public interface ITurnableTrap
{
    public Quaternion Turn(Transform trap, TurnType turnType, float speed);
}