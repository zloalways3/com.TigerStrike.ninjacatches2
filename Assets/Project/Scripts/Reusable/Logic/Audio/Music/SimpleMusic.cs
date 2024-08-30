public abstract class SimpleMusic : SimpleAudio
{
    protected override bool PlayingCondition => GlobalMusicData.Instance.IsPlaying;
    protected override bool PlayOnAwake => true;
}