public class Dash : Ability
{
    private EntityMovement _movement;
    private float _power;

    public override void Action()
    {
        _movement.Dash(_power);
    }

    public Dash(EntityMovement movement, float power, float takeDown) : base(takeDown)
    {
        _movement = movement;
        _power = power;
    }
}