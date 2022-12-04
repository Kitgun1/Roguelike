using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomTransiter : MonoBehaviour
{
    [SerializeField] private List<TransitButton> _buttons;
    [SerializeField] private List<Room> _rooms;

    public Room CurrentRoom { get; private set; }

    private void OnClick(RoomDirection direction)
    {
        RoomGrid targetPosition = CurrentRoom.Position;

        switch (direction)
        {
            case RoomDirection.Up:
                targetPosition.Position.y++;
                break;
            case RoomDirection.Down:
                targetPosition.Position.y--;
                break;
            case RoomDirection.Right:
                targetPosition.Position.x++;
                break;
            case RoomDirection.Left:
                targetPosition.Position.x--;
                break;
        }

        var targetRoom = _rooms.FirstOrDefault(p => p.Position.Position == targetPosition.Position);

        if (targetRoom != null)
        {
            targetRoom.Select();
            CurrentRoom = targetRoom;
        }
    }

    private void OnEnable()
    {
        foreach (var button in _buttons)
            button.OnClick += OnClick;
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
            button.OnClick -= OnClick;
    }
}