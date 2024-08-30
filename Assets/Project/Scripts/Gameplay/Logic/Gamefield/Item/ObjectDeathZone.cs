using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ObjectDeathZone : MonoBehaviour
{
    [SerializeField] private ObjectFalling _itemFalling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Object item)) return;

        _itemFalling.SetVelocity(item);
    }
}