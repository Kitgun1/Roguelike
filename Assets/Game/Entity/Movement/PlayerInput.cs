using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        Vector2 direction;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

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