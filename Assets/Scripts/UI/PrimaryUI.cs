using System.Collections;
using UnityEngine;

public abstract class PrimaryUI : MonoBehaviour
{
    [HideInInspector] public bool isOpened;

    public virtual void OpenWindow()
    {
        isOpened = true;
    }

    public virtual void CloseWindow()
    {
        isOpened = false;
    }
    public virtual void Toogle()
    {
        if (isOpened)
        {
            CloseWindow();
        }
        else
        {
            OpenWindow();
        }
    }

    public CanvasGroup visuals;
    [SerializeField] float duration;
    Coroutine coroutine;

    public void ShowVisuals()
    {
        visuals.gameObject.SetActive(true);
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(CanvasGroupAlphaCoroutine(0, 1, true));

    }

    public void HideVisuals()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(CanvasGroupAlphaCoroutine(1, 0, false));
    }
    public IEnumerator CanvasGroupAlphaCoroutine(float startAlpha, float endAlpha, bool enable)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.fixedUnscaledDeltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            visuals.alpha = alpha;
            yield return null;
        }
        visuals.gameObject.SetActive(enable);

    }
}
