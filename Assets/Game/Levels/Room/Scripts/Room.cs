using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<Mission> _missions;
    [SerializeField] private List<Trap> _traps;

    public IReadOnlyList<Mission> Missions => _missions;

    public void Select()
    {

    }

    private void OnMissionComplete(Mission mission)
    {
        mission.Complete -= OnMissionComplete;
    }

    private void OnEnable()
    {
        foreach (var mission in _missions)
            mission.Complete += OnMissionComplete;
    }

    private void OnDisable()
    {
        foreach (var mission in _missions)
            mission.Complete -= OnMissionComplete;
    }
}