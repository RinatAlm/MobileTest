using UnityEngine;

public class AnimalShape : MonoBehaviour
{
    public PolygonCollider2DShapeManager shapeResponse;
    public SpriteRenderer animalSpriteRenderer;
    public SpriteRenderer shapeSpriteRenderer;
    public AnimalShapeData data;

  
    public void SetAnimalShapeData(AnimalShapeData animalShapeData)
    {
        data = animalShapeData;
        shapeSpriteRenderer.color = data.color;
        animalSpriteRenderer.sprite = data.animalSprite;
        shapeSpriteRenderer.sprite = data.shapeSprite;
        shapeResponse.ResizeShape();

    }
}


