using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class AbstractToggleSubscriber : AbstractSubscriber
{
    private Toggle _toggle;

    protected virtual bool StartState { get; } = false;

    protected virtual void Initialize() { }
    protected virtual void HandleEnabled() { }
    protected virtual void HandleDisabled() { }

    protected override void Subscribe()
    {
        _toggle = GetComponent<Toggle>();

        _toggle.onValueChanged.AddListener((_) => Listener());
        _toggle.onValueChanged.AddListener(Toggle);

        Initialize();

        _toggle.isOn = StartState;
    }

    private void Toggle(bool value)
    {
        if (value) HandleEnabled();
        else HandleDisabled();
    }
}