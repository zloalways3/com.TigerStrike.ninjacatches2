using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicData : SimpleAudioData
{
    [SerializeField] private BackgroundLoop _backgroundLoop;

    public static GlobalMusicData Instance { get; private set; }

    protected override string PlayingKey => $"{nameof(GlobalMusicData)}IsPlaying";

    protected override IReadOnlyCollection<SimpleAudio> GetAudios()
    {
        var audios = new List<SimpleAudio>()
        {
            _backgroundLoop
        };

        return audios;
    }

    protected override void Initialize()
    {
        DestroyInstancesExcludeThis<GlobalMusicData>();
        Instance = this;
    }
}