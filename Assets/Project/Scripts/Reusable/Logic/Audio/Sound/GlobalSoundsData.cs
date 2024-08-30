using System.Collections.Generic;
using UnityEngine;

public class GlobalSoundsData : SimpleAudioData
{
    [SerializeField] private TapSound _tapSound;

    public static GlobalSoundsData Instance { get; private set; }

    protected override string PlayingKey => $"{nameof(GlobalSoundsData)}IsPlaying";

    protected override IReadOnlyCollection<SimpleAudio> GetAudios()
    {
        var audios = new List<SimpleAudio>()
        {
            _tapSound
        };

        return audios;
    }

    protected override void Initialize()
    {
        DestroyInstancesExcludeThis<GlobalSoundsData>();
        Instance = this;
    }
}