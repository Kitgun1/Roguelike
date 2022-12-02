public abstract class Ability
{
    protected Ability(float takeDownTime)
    {
        TakeDownTime = takeDownTime;
        AbleToAct = true;
    }

    public float TakeDownTime { get; private set; }
    public bool AbleToAct = true;

    public abstract void Action();

}