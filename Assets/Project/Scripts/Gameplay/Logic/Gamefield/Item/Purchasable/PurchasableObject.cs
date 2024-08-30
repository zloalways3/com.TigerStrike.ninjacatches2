using UnityEngine;

public class PurchasableObject : Object, ISellable
{
    [SerializeField] [Min(1)] private int _price = 1;

    public int Cost => _price;

    protected override void HandlePickuped()
    {
        Score.TryAdd(this);
    }
}