using UnityEngine;

[CreateAssetMenu(menuName = "Configs/SpawnConfig")]
public class AnimalShapeSpawnerConfigSO : ScriptableObject
{
    public int maxPairsCount;
    public int animalNumToMatch = 3;

}
