using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomTransiter : MonoBehaviour
{
    [SerializeField] private List<TransitButton> _buttons;
    [SerializeField] private Level _level;

    public Room CurrentRoom { get; private set; }

    private void OnClick(RoomDirection direction)
    {
        CurrentRoom = _level.CurrentRoom;
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

        var targetRoom = _level.Rooms.FirstOrDefault(p => p.Position.Position == targetPosition.Position);

        if (targetRoom != null)
        {
            targetRoom.Select();
            _level.SelectRoom(targetRoom);
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