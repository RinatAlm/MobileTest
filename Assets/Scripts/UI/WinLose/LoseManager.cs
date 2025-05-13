public class LoseManager : PrimaryUI
{
    public AnimalShapePicker animalShapePicker;

    public void Init(AnimalShapePicker animalShapePicker)
    {
        this.animalShapePicker = animalShapePicker;
    }
    public override void OpenWindow()
    {
        base.OpenWindow();
        ShowVisuals();
        animalShapePicker.Disable();
    }

    public override void CloseWindow()
    {
        base.CloseWindow();
        HideVisuals();
    }
}
