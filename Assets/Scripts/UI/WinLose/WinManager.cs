using UnityEngine;

public class WinManager : PrimaryUI
{
    public override void OpenWindow()
    {
        base.OpenWindow();
        ShowVisuals();
    }

    public override void CloseWindow()
    {
        base.CloseWindow();
        HideVisuals();
    }
}
