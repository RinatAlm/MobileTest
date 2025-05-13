using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public const string ANIMATION = "Animation";
    public const string EMPTY = "Empty";
    private const string SPEED = "Speed";
    public string currentState;
    public Animator animator;
    [HideInInspector] public AnimatorOverrideController animatorOverrideController;

    public void Init()
    {
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }

    public float ChangeAnimation(AnimationClip clip, float animationSpeed, float offset = 0)
    {
        currentState = clip.name;
        float animationDuration = clip.length / animationSpeed;
        animator.enabled = true;
        animatorOverrideController[ANIMATION] = clip;
        animator.runtimeAnimatorController = animatorOverrideController;
        animator.SetFloat(SPEED, animationSpeed);
        animator.Play(ANIMATION, -1, offset);
        return animationDuration;
    }

    public void PlayEmpty()
    {
        animator.Play(EMPTY, -1, 0);
    }

}
