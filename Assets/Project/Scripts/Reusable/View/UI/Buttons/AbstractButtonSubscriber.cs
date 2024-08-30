using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class AbstractButtonSubscriber : AbstractSubscriber
{
    protected Button Button { get; private set; }

    protected virtual void Initialize() { }

    protected override void Subscribe()
    {
        GetComponent<Button>().onClick.AddListener(Listener);
        Initialize();
    }
}