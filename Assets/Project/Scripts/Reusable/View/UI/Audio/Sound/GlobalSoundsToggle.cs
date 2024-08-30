public class GlobalSoundsToggle : SimpleAudioToggle
{
    protected override SimpleAudioData AudioData => GlobalSoundsData.Instance;
}