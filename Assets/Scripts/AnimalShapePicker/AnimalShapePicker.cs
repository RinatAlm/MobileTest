using System;
using UnityEngine;

public class AnimalShapePicker : MonoBehaviour
{
    const string ANIMALSHAPETAG = "AnimalShape";
    [SerializeField] private GameObject explosionPrefab;
    public Action<AnimalShapeData> onPicked;
    public void Pick()
    {
        Vector2 clickPosition = InputManager.instance.inputActions.Control.MousePosition.ReadValue<Vector2>();
        Vector2 worldSpaceMousePos = Camera.main.ScreenToWorldPoint(clickPosition);
        Debug.Log(worldSpaceMousePos);
        RaycastHit2D raycastHit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);//Point a ray from the camera to the mouse position
        if(raycastHit.collider != null && raycastHit.collider.CompareTag(ANIMALSHAPETAG))
        {
            AnimalShape animalShape = raycastHit.collider.transform.parent.GetComponent<AnimalShape>();
            Debug.Log(animalShape.data.animalType.ToString() + " " + animalShape.data.shapeType.ToString());
            Instantiate(explosionPrefab, raycastHit.collider.transform.position,Quaternion.identity);
            ObjectPoolerV2.EnqueueObject(animalShape, AnimalShapeSpawner.POOLKEY);
            onPicked?.Invoke(animalShape.data);
        }
        //Get a collider from the ray collision

        //Get Animal shape 

        //Put animal shape data into ui animal shape
    }
}
