using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(CanvasGroup))]
public class CanvasHandler : MonoBehaviour, ICanvasHandler
{
    Animator animator; 
    CanvasGroup canvasGroup;
    [SerializeField] private CanvasEnums myCanvasName;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void CloseCanvas()
    {
        animator.SetTrigger("Rewind");
        canvasGroup.interactable = false;
        StartCoroutine(StopWatch(() =>
        {
            canvasGroup.blocksRaycasts = false;    
            canvasGroup.alpha = 0;    
            Debug.Log("Timer finished!");
        }));
    }

    public void OpenCanvas()
    {
        animator.SetTrigger("Animate");
        canvasGroup.alpha = 1;
        StartCoroutine(StopWatch(() =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            Debug.Log("Timer finished!");
        }));
    }

    private IEnumerator StopWatch(Action OnComplete)
    {
        float timer = 0;

        while (timer < .4f)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;  
        }
        OnComplete?.Invoke();   
    }

    public CanvasEnums GetCanvasName()
    {
        return myCanvasName;
    }
}