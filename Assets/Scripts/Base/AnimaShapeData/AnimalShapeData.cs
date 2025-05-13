using UnityEngine;

public class AnimalShapeData
{
    public AnimalType animalType;
    public ShapeType shapeType;
    public Color color;
    public Sprite animalSprite;
    public Sprite shapeSprite;

    public bool Compare(AnimalShapeData data)
    {
        if (animalType == data.animalType && shapeType == data.shapeType && color == data.color)
            return true;
        else
            return false;
    }
}
