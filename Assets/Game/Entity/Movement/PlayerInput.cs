using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        Vector2 direction;

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        ReadButtons();
        _player.Move(direction);
    }

    private void ReadButtons()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _player.UseAblility();
            StartCoroutine(_player.Movement.ReturnToMove());
        }
    }
}