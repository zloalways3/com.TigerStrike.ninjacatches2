using System.Collections.Generic;
using UnityEngine;

public abstract class SimpleAudioData : MonoBehaviour
{
    private const int EnabledValue = 1;
    private const int DisabledValue = 0;

    public bool IsPlaying => PlayerPrefs.GetInt(PlayingKey, EnabledValue) == EnabledValue;

    protected abstract IReadOnlyCollection<SimpleAudio> GetAudios();
    protected abstract string PlayingKey { get; }

    public void Enable()
    {
        var audios = GetAudios();

        foreach (var audio in audios)
        {
            audio.UnMute();
        }

        PlayerPrefs.SetInt(PlayingKey, EnabledValue);
    }

    public void Disable()
    {
        var audios = GetAudios();

        foreach (var audio in audios)
        {
            audio.Mute();
        }

        PlayerPrefs.SetInt(PlayingKey, DisabledValue);
    }

    protected virtual void Initialize() { }

    protected void DestroyInstancesExcludeThis<T>() where T : SimpleAudioData
    {
        var musics = FindObjectsOfType<T>();

        foreach (var music in musics)
            if (music != this)
                Destroy(music.gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        if (IsPlaying) Enable();
        else Disable();

        Initialize();
    }
}