using System;

public static class Score
{
    public static event Action<int> Updated;

    public static int Value { get; private set; }

    public static void Reset()
    {
        Value = 0;
        Updated?.Invoke(Value);
    }

    public static bool TryAdd(ISellable purhasable)
    {
        if (purhasable.Cost <= 0) return false;

        Add(purhasable);

        return true;
    }

    private static void Add(ISellable purhasable)
    {
        Value += purhasable.Cost;
        Updated?.Invoke(Value);
    }
}