using UnityEngine;

public class SceneBootstrap : MonoBehaviour
{
    public InputManager inputManager;
    public AnimalShapeSpawner spawner;
    public ActionPerformer actionPerformer;
    public AnimalShapePicker animalShapePicker;
    public MatchTableUIManager matchTableUI;
    public WinManager winManager;
    public LoseManager loseManager;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        inputManager.Init();
        actionPerformer.Init();
        spawner.Init();
        spawner.Spawn();

        matchTableUI.Init();
        animalShapePicker.onPicked += matchTableUI.OnPicked;
        loseManager.Init(animalShapePicker);

        matchTableUI.maxPairsCount = spawner.maxPairsCount;
        matchTableUI.onGameLost += loseManager.OpenWindow;
        matchTableUI.onGameWon += winManager.OpenWindow;

    }
}
