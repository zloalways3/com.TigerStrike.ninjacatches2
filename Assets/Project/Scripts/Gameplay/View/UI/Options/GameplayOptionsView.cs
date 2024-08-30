using UnityEngine;
using UnityEngine.UI;

public class GameplayOptionsView : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    public void Show()
    {
        gameObject.SetActive(true);
        GamePause.TryPause();
    }

    private void Awake()
    {
        _exitButton.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        gameObject.SetActive(false);
        GamePause.TryResume();
    }
}