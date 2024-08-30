public abstract class SimpleAudioToggle : AbstractToggleSubscriber
{
    protected abstract SimpleAudioData AudioData { get; }

    protected override bool StartState => AudioData.IsPlaying;

    protected override void HandleEnabled()
    {
        AudioData.Enable();
    }

    protected override void HandleDisabled()
    {
        AudioData.Disable();
    }
}