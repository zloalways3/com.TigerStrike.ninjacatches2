using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public abstract class SimpleAudio : MonoBehaviour
{
    private AudioSource _source;

    protected abstract bool PlayOnAwake { get; }
    protected abstract bool PlayingCondition { get; }

    protected virtual event Action PlayEvent { add { } remove { } }

    protected virtual void Initiaize() { }

    public bool TryPlay()
    {
        if (!PlayingCondition) return false;

        _source.Play();

        return true;
    }

    public void Mute()
    {
        _source.mute = true;
    }

    public void UnMute()
    {
        _source.mute = false;
    }

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        _source.playOnAwake = PlayOnAwake;

        Initiaize();

        PlayEvent += () => TryPlay();
    }

    private void OnDestroy()
    {
        PlayEvent -= () => TryPlay();
    }
}