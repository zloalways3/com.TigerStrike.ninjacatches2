using UnityEngine;

public class LoseView : MonoBehaviour
{
    [SerializeField] private PlayerExecution _playerDeath;
    [SerializeField] private GameObject _panel;

    private void Awake()
    {
        _playerDeath.Died += Enable;
    }

    private void Enable()
    {
        GamePause.TryPause();
        _panel.SetActive(true);
    }

    private void OnDestroy()
    {
        _playerDeath.Died -= Enable;
    }
}