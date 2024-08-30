public abstract class AbstractSound : SimpleAudio
{
    protected override bool PlayingCondition => GlobalSoundsData.Instance.IsPlaying;
    protected override bool PlayOnAwake => false;
}