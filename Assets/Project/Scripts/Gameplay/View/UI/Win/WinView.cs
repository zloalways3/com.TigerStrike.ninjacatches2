using UnityEngine;

public class WinView : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    private void Awake()
    {
        LevelTarget.Reached += Enable;
    }

    private void Enable()
    {
        GamePause.TryPause();
        _panel.SetActive(true);
    }

    private void OnDestroy()
    {
        LevelTarget.Reached -= Enable;
    }
}