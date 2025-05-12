using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalShapeSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public int maxPairsCount;
    public int animalNumToMatch = 3;
    public GameObject animalShapePrefab;
    public const string POOLKEY = "AnimalShape";


    [Header("Generation")]
    public List<Sprite> animalSprites = new List<Sprite>();
    public List<Sprite> shapeSprites = new List<Sprite>();
    public void Init()
    {
        //Pool animas shapes
        int animalShapesToSpawn = maxPairsCount * animalNumToMatch;
        for(int i = 0; i< animalShapesToSpawn; i++)
        {
            AnimalShape animalShape = Instantiate(animalShapePrefab).GetComponent<AnimalShape>();
            ObjectPoolerV2.EnqueueNewInstance(animalShape, POOLKEY);
        }
    }

    public void Spawn()
    {
        for(int i = 0; i< maxPairsCount; i++)
        {
            //Pick animal
            //Pick random shape
            //Pick random color
            AnimalType randomAnimalType = (AnimalType)Random.Range(0, Enum.GetValues(typeof(AnimalType)).Length);
            ShapeType randomShape = (ShapeType)Random.Range(0, Enum.GetValues(typeof(ShapeType)).Length);
            Color color = GetRandomColor();

            for(int j = 0; j < animalNumToMatch;j++)
            {
                AnimalShape animalShape = ObjectPoolerV2.DequeuObject<AnimalShape>(POOLKEY);
                animalShape.SetAnimalType(randomAnimalType);
                animalShape.SetAnimalShape(randomShape);
                animalShape.SetColor(color);
                animalShape.SetAnimalSprite(GetAnimalSprite(randomAnimalType));
                animalShape.SetShapeSprite(GetShapeSprite(randomShape));
                animalShape.transform.position = spawnPoint.position;
            }
        }
       
    }

    private Sprite GetAnimalSprite(AnimalType animalType)
    {
        foreach(Sprite sprite in animalSprites)
        {
            Debug.Log(sprite.name);
            if(sprite.name.Equals(animalType.ToString(),StringComparison.OrdinalIgnoreCase))
            {
                return sprite;
            }
        }
        return null;
    }

    private Sprite GetShapeSprite(ShapeType shapeType)
    {
        foreach (Sprite sprite in shapeSprites)
        {
            Debug.Log(sprite.name);
            if (sprite.name.Equals(shapeType.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sprite;
            }
        }
        return null;
    }


    public Color GetRandomColor()
    {
        return Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
