using System.Collections.Generic;
using UnityEngine;

public static class Collider2DExtensions
{
    public static void TryUpdateShapeToAttachedSprite(this PolygonCollider2D collider, SpriteRenderer spriteRenderer)
    {
        collider.UpdateShapeToSprite(spriteRenderer);
    }

    public static void UpdateShapeToSprite(this PolygonCollider2D collider, SpriteRenderer spriteRenderer)
    {
        // ensure both valid
        if (collider != null && spriteRenderer.sprite != null)
        {
            // update count
            collider.pathCount = spriteRenderer.sprite.GetPhysicsShapeCount();

            // new paths variable
            List<Vector2> path = new List<Vector2>();

            // loop path count
            for (int i = 0; i < collider.pathCount; i++)
            {
                // clear
                path.Clear();
                // get shape
                spriteRenderer.sprite.GetPhysicsShape(i, path);

                if(spriteRenderer.drawMode == SpriteDrawMode.Sliced)
                {
                    ////Resize shape to sprite size
                    for (int j = 0; j < path.Count; j++)
                    {
                        Vector2 newPath = path[j];
                        newPath.x *= 5;// spriteRenderer.size.x / (sprite.size / 128); 
                        newPath.y *= 5;
                        path[j] = newPath;
                    }

                }
                // set path
                collider.SetPath(i, path.ToArray());
            }
        }
    }
}