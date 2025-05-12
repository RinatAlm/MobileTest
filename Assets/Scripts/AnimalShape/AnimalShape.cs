using UnityEngine;

public class AnimalShape : MonoBehaviour
{
    public PolygonCollider2DShapeManager shapeResponse;
    public AnimalType animalType;
    public ShapeType shapeType;

}

public enum AnimalType
{

}

public enum ShapeType
{ 
    Triangle,
    Star,
    Circle,
    Hexagon,
}

