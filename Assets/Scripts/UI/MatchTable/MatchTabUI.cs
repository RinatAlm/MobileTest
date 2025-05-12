using UnityEngine;

public class MatchTabUI : MonoBehaviour
{
    public float animSpeed;
    public AnimationClip animationClip;
    public AnimationPlayer animationPlayer;
    public AnimalShapeData animalShapeData;
  
    public void Init()
    {
        animationPlayer.Init();
        float offset = Random.Range(0f, 1f);
        animationPlayer.ChangeAnimation(animationClip, animSpeed, offset);
    }
}
