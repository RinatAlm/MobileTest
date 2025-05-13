using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public InputActions inputActions;

    public void Init()
    {
        instance = this;
        inputActions = new InputActions();
    }
}
