using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MatchTabUI : MonoBehaviour
{
    public float animSpeed;
    public AnimationClip animationClip;
    public AnimationPlayer animationPlayer;
    public AnimalShapeData animalShapeData;

    [Header("Visuals")]
    [SerializeField] private Image animalIconImage;
    [SerializeField] private Image shapeImage;
  
    public void Init()
    {
        animationPlayer.Init();
        float offset = Random.Range(0f, 1f);
        animationPlayer.ChangeAnimation(animationClip, animSpeed, offset);
        animalIconImage.gameObject.SetActive(false);
        shapeImage.gameObject.SetActive(false);
    }

    public void SetAnimalShapeData(AnimalShapeData animalShapeData)
    {
        this.animalShapeData = animalShapeData;
        if(animalShapeData == null)
        {
            float offset = Random.Range(0f, 1f);
            animationPlayer.ChangeAnimation(animationClip, animSpeed, offset);
            animalIconImage.gameObject.SetActive(false);
            shapeImage.gameObject.SetActive(false);
        }
        else
        {
            animationPlayer.PlayEmpty();
            animalIconImage.gameObject.SetActive(true);
            shapeImage.gameObject.SetActive(true);
            animalIconImage.sprite = animalShapeData.animalSprite;
            shapeImage.sprite = animalShapeData.shapeSprite;
            shapeImage.color = animalShapeData.color;
        }
    }

    public void StartMovementCoroutine(MatchTabUI destination)
    {
        StartCoroutine(MovementCoroutine(destination));
    }

    private IEnumerator MovementCoroutine(MatchTabUI destination)
    {
        float duration = 1;
        float elapsedTime = 0;
        Vector2 startPos = transform.position;
        Vector2 endPos = destination.transform.position;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            Vector2 nextPos = Vector2.Lerp(startPos, endPos, duration);
            transform.position = nextPos;
            yield return new WaitForFixedUpdate();
        }
        destination.SetAnimalShapeData(animalShapeData);
    }
}
