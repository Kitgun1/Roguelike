using UnityEngine;
using UnityEngine.Events;

public class TransitButton : ButtonHandler
{
    [SerializeField] private RoomDirection _direction;

    public new event UnityAction<RoomDirection> OnClick;

    private void OnButtonClick()
    {
        OnClick?.Invoke(_direction);
    }

    private new void OnEnable()
    {
        base.OnEnable();
        base.OnClick += OnButtonClick;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        base.OnClick -= OnButtonClick;
    }
}

public enum RoomDirection
{
    Up,
    Down,
    Left,
    Right
}