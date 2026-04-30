using UnityEngine;

public class FaderHandler : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SceneActions.CloseFader += OnFaderClose;
    }

    private void OnDisable()
    {
        SceneActions.CloseFader -= OnFaderClose;
    }

    private void OnFaderClose()
    {
        animator.SetTrigger("Close");
    }
}
