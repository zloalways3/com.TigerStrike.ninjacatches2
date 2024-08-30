using UnityEngine;

public abstract class AbstractSubscriber : MonoBehaviour
{
    private void Start()
    {
        Subscribe();
    }

    protected virtual void Listener() { }
    protected abstract void Subscribe();
}