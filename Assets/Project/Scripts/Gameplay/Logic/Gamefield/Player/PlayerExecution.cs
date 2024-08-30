using System;
using UnityEngine;

public class PlayerExecution : MonoBehaviour
{
    public event Action Died;

    private void Awake() => KillingObject.Collected += Die;

    private void Die()
    {
        Destroy(gameObject);
        GamePause.TryPause();
        Died?.Invoke();
    }

    private void OnDestroy() => KillingObject.Collected -= Die;
}