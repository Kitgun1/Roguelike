using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private List<Room> _rooms;
    [SerializeField] private Player _player;

    public Room CurrentRoom { get; private set; }
    public IReadOnlyList<Room> Rooms => _rooms;

    public event UnityAction<Room> OnRoomChanged;

    private void Start()
    {
        SelectRoom(_rooms[0]);
    }

    public void StartGame()
    {
        CurrentRoom.OnLevelStarted();
    }

    public void SelectRoom(Room room)
    {
        CurrentRoom = room;
        room.Select();

        OnRoomChanged?.Invoke(room);
    }

    public void OnPlayerDied()
    {
        CurrentRoom.OnLevelFinished();
    }
}