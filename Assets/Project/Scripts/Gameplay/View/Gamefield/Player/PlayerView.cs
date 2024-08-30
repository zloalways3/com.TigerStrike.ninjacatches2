using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private PlayerTravelling _playerMovement;

    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _playerMovement.DirectionChanged += ShowChangedDirection;
    }

    private void ShowChangedDirection(PlayerTravellingDirection direction)
    {
        _renderer.flipX = !_renderer.flipX;
    }

    private void OnDestroy()
    {
        _playerMovement.DirectionChanged -= ShowChangedDirection;
    }
}