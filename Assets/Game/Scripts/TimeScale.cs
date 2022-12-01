public static class TimeScale
{
    public static float Value { get; private set; }

    public static void Set(float value)
    {
        if (value < 0 || value > 1)
            return;

        Value = value;
    }
}