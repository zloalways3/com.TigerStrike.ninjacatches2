public class RestartButton : AbstractButtonSubscriber
{
    protected override void Listener()
    {
        SceneExecution.RestartScene();
    }
}