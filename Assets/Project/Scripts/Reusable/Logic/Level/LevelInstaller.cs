using System;
using UnityEngine;

public class LevelInstaller : MonoBehaviour
{
    private const string AccessSceneName = SceneNameList.Menu;
    private const string MaxUnlockedLevelSaveKey = "MaxUnlockedLevel";
    private const int DefaultMaxUnlockedLevel = 1;

    private void Awake()
    {
        if (!ActiveSceneNameComparer.CompareActiveSceneName(AccessSceneName)) throw new Exception($"{nameof(LevelInstaller)} must be located on \"{AccessSceneName}\" scene");
        if (transform.childCount > 0) throw new Exception($"{nameof(LevelInstaller)} must have no child objects");
        if (transform.parent != null) throw new Exception($"{nameof(LevelInstaller)} must be the root GameObject in the hierarchy in the scene");

        DontDestroyOnLoad(gameObject);

        var maxUnlockedLevel = PlayerPrefs.GetInt(MaxUnlockedLevelSaveKey, DefaultMaxUnlockedLevel);

        Level.TryInstall(maxUnlockedLevel);

        Level.MaxUnlockedLevelUpdated += SaveMaxUnlockedLevelValue;
    }

    private void SaveMaxUnlockedLevelValue(int value) => PlayerPrefs.SetInt(MaxUnlockedLevelSaveKey, value);

    private void OnDestroy()
    {
        Level.Reset();

        Level.MaxUnlockedLevelUpdated -= SaveMaxUnlockedLevelValue;
    }
}