using UnityEngine;

public class SceneBootstrap : MonoBehaviour
{
    public InputManager inputManager;
    public AnimalShapeSpawner spawner;
    public ActionPerformer actionPerformer;
    public AnimalShapePicker animalShapePicker;
    public MatchTableUIManager matchTableUI;
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
    }
}
