using UnityEngine;

[CreateAssetMenu(fileName = "LiveMission", menuName = "CreateMissions/Missions", order = 1)]
public class LiveMission : Mission
{
    [field: SerializeField] public float Time { get; private set; }
}