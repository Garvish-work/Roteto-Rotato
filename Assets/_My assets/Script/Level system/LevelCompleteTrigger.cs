using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    int ballsIndex = 0;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag ("Player"))
        {
            ballsIndex++;
            if (ballsIndex >= 4)
            {
                LevelActions.LevelCompleted?.Invoke();
                AudioActions.PlaySfx?.Invoke(SfxType.LEVEL_COMPLETE);
            }
        }

    }
}
