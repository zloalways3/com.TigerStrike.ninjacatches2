public class ToggleTapSound : AbstractToggleSubscriber
{
    protected override void Listener()
    {
        TapSoundRequest.Send();
    }
}