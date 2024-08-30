public class GlobalMusicToggle : SimpleAudioToggle
{
    protected override SimpleAudioData AudioData => GlobalMusicData.Instance;
}