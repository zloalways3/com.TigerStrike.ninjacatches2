using System;

public class TapSound : AbstractSound
{
    protected override event Action PlayEvent
    {
        add
        {
            TapSoundRequest.Sent += value;
        }
        remove
        {
            TapSoundRequest.Sent -= value;
        }
    }
}