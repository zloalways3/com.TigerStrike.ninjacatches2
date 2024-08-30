using System;

public static class Level
{
    private const string InstallAccessSceneName = SceneNameList.Menu;
    private const string GetAccessSceneName = SceneNameList.Gameplay;
    private const string SetAccessSceneName = SceneNameList.Menu;
    private const int MaxValue = 12;

    public static event Action<int> MaxUnlockedLevelUpdated;

    private static int _value;
    private static int _maxUnlockedLevel;

    public static bool IsLastLevel => _value == MaxValue;

    private static bool IsInstallAccessScene => ActiveSceneNameComparer.CompareActiveSceneName(InstallAccessSceneName);
    private static bool IsGetAccessScene => ActiveSceneNameComparer.CompareActiveSceneName(GetAccessSceneName);
    private static bool IsSetAccessScene => ActiveSceneNameComparer.CompareActiveSceneName(SetAccessSceneName);

    public static bool TryGetValue(out int value)
    {
        value = default;
        if (!IsGetAccessScene) return false;

        value = _value;

        return true;
    }

    public static bool TryGetMaxUnlocked(out int value)
    {
        value = default;
        if (!IsSetAccessScene) return false;

        value = _maxUnlockedLevel;

        return true;
    }

    public static bool TryInstall(int maxUnlocked)
    {
        if (_maxUnlockedLevel > 0) return false;
        if (!IsInstallAccessScene) return false;

        _maxUnlockedLevel = maxUnlocked;

        return true;
    }

    public static bool TrySetValue(int level)
    {
        if (!IsSetAccessScene) return false;
        if (level <= (int)default || level > MaxValue) throw new ArgumentOutOfRangeException();

        _value = level;

        return true;
    }

    public static void Reset() => _maxUnlockedLevel = 0;

    public static bool TryNext()
    {
        if (!IsGetAccessScene) return false;
        if (IsLastLevel) return false;

        _value++;

        _maxUnlockedLevel++;
        MaxUnlockedLevelUpdated?.Invoke(_maxUnlockedLevel);

        return true;
    }
}