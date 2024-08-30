using System;
using UnityEngine;

public class LevelTarget : MonoBehaviour
{
    public static event Action Reached;

    [SerializeField] [Min(1)] private int _value = 1;

    public static int Value { get; private set; }

    private void Awake()
    {
        if (!Level.TryGetValue(out var levelValue)) return;
        Value = _value * Mathf.Max(levelValue, 1);

        Score.Updated += CheckReached;
    }

    private void CheckReached(int value)
    {
        if (value < Value) return;
        Reached?.Invoke();
    }

    private void OnDestroy()
    {
        Score.Updated -= CheckReached;
    }
}