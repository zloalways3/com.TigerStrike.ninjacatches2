public class ButtonTapSound : AbstractButtonSubscriber
{
    protected override void Listener()
    {
        TapSoundRequest.Send();
    }
}