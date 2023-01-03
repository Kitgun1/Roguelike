using UnityEngine;

public class EntityAnimation : IAnimatable
{
    private Animator _animator;

    private static string HorizontalInput = nameof(HorizontalInput);
    private static string VerticalInput = nameof(VerticalInput);
    private static string Walking = nameof(Walking);

    public EntityAnimation(Animator animator)
    {
        _animator = animator;
    }

    public void Animate(Vector2 direction)
    {
        _animator.SetBool(Walking, direction != Vector2.zero);

        if (direction != Vector2.zero)
        {
            _animator.SetFloat(HorizontalInput, direction.x);
            _animator.SetFloat(VerticalInput, direction.y);
        }
    }
}