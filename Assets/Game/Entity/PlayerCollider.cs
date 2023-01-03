using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out TrapCollider trap))
        {
            _player.TryDie();
        }
    }
} 