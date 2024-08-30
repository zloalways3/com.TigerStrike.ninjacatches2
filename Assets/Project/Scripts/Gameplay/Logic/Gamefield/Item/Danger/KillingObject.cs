using System;

public class KillingObject : Object
{
    public static event Action Collected;

    protected override void HandlePickuped()
    {
        Collected?.Invoke();
    }
}