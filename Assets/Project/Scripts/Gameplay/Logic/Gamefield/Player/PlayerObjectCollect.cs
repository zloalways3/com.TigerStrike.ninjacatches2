using UnityEngine;

public class PlayerObjectCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Object thing)) return;

        thing.Pickup();
    }
}