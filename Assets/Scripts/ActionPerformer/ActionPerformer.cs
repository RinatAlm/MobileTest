using UnityEngine;
using UnityEngine.InputSystem;

public class ActionPerformer : MonoBehaviour
{
    public InputActions inputActions;
    public AnimalShapePicker animalShapePicker;
    public void Init()
    {
        inputActions = InputManager.instance.inputActions;
        inputActions.Enable();

        inputActions.Control.Click.performed += PickAnimalShape;
    }

    public void PickAnimalShape(InputAction.CallbackContext context)
    {
        animalShapePicker.Pick();
    }
}
