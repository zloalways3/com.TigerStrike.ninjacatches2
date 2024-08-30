public class NextLevelButton : AbstractButtonSubscriber
{
    protected override void Listener()
    {
        SceneExecution.RestartScene();
        Level.TryNext();
    }
}