using UnityEngine;

public class SceneLoadingButton : AbstractButtonSubscriber
{
    [SerializeField] private string _name;

    protected override void Listener()
    {
        SceneExecution.Load(_name);
    }
}