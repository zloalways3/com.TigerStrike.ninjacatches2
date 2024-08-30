using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelRunButton : AbstractButtonSubscriber
{
    private const string AccessSceneName = SceneNameList.Menu;
    private const string LevelSceneName = SceneNameList.Gameplay;

    [SerializeField] [Range(1, 15)] private int _level = 1;
    [SerializeField] private GameObject _lockView;

    protected override void Initialize()
    {
        if (!ActiveSceneNameComparer.CompareActiveSceneName(AccessSceneName)) return;
        if (!Level.TryGetMaxUnlocked(out var maxUnlockedLevel)) return;

        var unlocked = _level <= maxUnlockedLevel;

        GetComponent<Button>().interactable = unlocked;

        _lockView.SetActive(!unlocked);
    }

    protected override void Listener()
    {
        SceneExecution.Load(LevelSceneName);
        Level.TrySetValue(_level);
    }
}