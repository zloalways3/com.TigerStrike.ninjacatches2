using System;

public static class TapSoundRequest
{
    public static event Action Sent;

    public static void Send()
    {
        Sent?.Invoke();
    }
}