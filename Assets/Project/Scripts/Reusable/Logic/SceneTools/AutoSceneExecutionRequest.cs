using UnityEngine;

public class AutoSceneExecutionRequest : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void Start()
    {
        SceneExecution.Load(_sceneName);
    }
}