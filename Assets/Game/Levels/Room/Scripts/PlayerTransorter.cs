using UnityEngine;

public class PlayerTransorter : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Player _player;

    private void OnRoomChanged(Room room)
    {
        _player.transform.SetParent(room.transform, false);
    }

    private void OnEnable()
    {
        _level.OnRoomChanged += OnRoomChanged;
    }


    private void OnDisable()
    {
        _level.OnRoomChanged -= OnRoomChanged;
    }
}