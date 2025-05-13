using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimalShapeSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public AnimalShapeSpawnerConfigSO config;
    public int maxPairsCount => config.maxPairsCount;
    public int animalNumToMatch => config.animalNumToMatch;
    public GameObject animalShapePrefab;
    public const string POOLKEY = "AnimalShape";


    [Header("Generation")]
    public List<Sprite> animalSprites = new List<Sprite>();
    public List<Sprite> shapeSprites = new List<Sprite>();
    public List<Color> colors = new List<Color>();
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
                AnimalShapeData animalShapeData = new AnimalShapeData();
                animalShapeData.animalType = randomAnimalType;
                animalShapeData.shapeType = randomShape;
                animalShapeData.color = color;
                animalShapeData.animalSprite = GetAnimalSprite(randomAnimalType);
                animalShapeData.shapeSprite = GetShapeSprite(randomShape);
                animalShape.SetAnimalShapeData(animalShapeData);
                animalShape.transform.position = spawnPoint.position;
            }
        }
       
    }

    private Sprite GetAnimalSprite(AnimalType animalType)
    {
        foreach(Sprite sprite in animalSprites)
        {
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
            if (sprite.name.Equals(shapeType.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return sprite;
            }
        }
        return null;
    }


    public Color GetRandomColor()
    {
        //return Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        return colors[Random.Range(0,colors.Count)];
    }
}
