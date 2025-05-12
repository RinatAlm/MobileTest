using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class PolygonCollider2DShapeManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [ContextMenu("Resize To Sprite Shape")]
    public void ResizeShape()
    {
        PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();
        polygonCollider.TryUpdateShapeToAttachedSprite(spriteRenderer);
    }

}
