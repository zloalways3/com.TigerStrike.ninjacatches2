using UnityEngine;

public class EscapeButton : AbstractButtonSubscriber
{
    protected override void Listener()
    {
        Application.Quit();
    }
}