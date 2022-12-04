using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransiter : MonoBehaviour
{
    [SerializeField] private List<TransitButton> _buttons;
    [SerializeField] private List<Room> _rooms;

    private void OnClick(RoomDirection direction)
    {

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