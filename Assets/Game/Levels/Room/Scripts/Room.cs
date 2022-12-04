using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<Mission> _missions;
    [SerializeField] private List<Trap> _traps;
    [SerializeField] private bool _open;
    [SerializeField] private RoomGrid _position;

    public bool Open => _open;
    public IReadOnlyList<Mission> Missions => _missions;
    public RoomGrid Position => _position;

    public void Select()
    {
        
    }

    public void OpenRoom()
    {
        _open = true;
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