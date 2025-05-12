using UnityEngine;

public class AnimalShape : MonoBehaviour
{
    public PolygonCollider2DShapeManager shapeResponse;
    public SpriteRenderer animalSpriteRenderer;
    public SpriteRenderer shapeSpriteRenderer;
    public AnimalShapeData data;

    public void SetAnimalType(AnimalType animalType)
    {
        data.animalType = animalType;
    }

    public void SetAnimalShape(ShapeType shapeType)
    {
        data.shapeType = shapeType;
    }

    public void SetColor(Color color)
    {
        data.color = color;
        shapeSpriteRenderer.color = color;
    }

    public void SetAnimalSprite(Sprite sprite)
    {
        animalSpriteRenderer.sprite = sprite;
    }

    public void SetShapeSprite(Sprite sprite)
    {
        shapeSpriteRenderer.sprite = sprite;
        shapeResponse.ResizeShape();
    }
}

public struct AnimalShapeData
{
    public AnimalType animalType;
    public ShapeType shapeType;
    public Color color;
}

public enum AnimalType
{
    chick,
    dog,
    horse,
    pig,
    snake,

}

public enum ShapeType
{ 
    triangle,
    star,
    circle,
    hexagon,
}

