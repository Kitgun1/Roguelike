using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private List<Room> _rooms;
    [SerializeField] private Player _player;

    public Room CurrentRoom { get; private set; }

    public event UnityAction<Room> OnRoomChanged;

    private void Start()
    {
        CurrentRoom = _rooms[0];
    }

    public void StartGame()
    {
        SelectRoom(_rooms[0]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
            SelectRoom(_rooms[0]);
        if (Input.GetKeyDown(KeyCode.Keypad2))
            SelectRoom(_rooms[1]);
        if (Input.GetKeyDown(KeyCode.Keypad3))
            SelectRoom(_rooms[2]);
        if (Input.GetKeyDown(KeyCode.Keypad4))
            SelectRoom(_rooms[3]);
        if (Input.GetKeyDown(KeyCode.Keypad5))
            SelectRoom(_rooms[4]);
    }

    public void SelectRoom(Room room)
    {
        CurrentRoom = room;
        room.Select();

        OnRoomChanged?.Invoke(room);
    }
}