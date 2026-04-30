using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    private void OnEnable()
    {
        SceneActions.ChangeScene += OnChangeScene;
    }

    private void OnDisable()
    {
        SceneActions.ChangeScene -= OnChangeScene;
    }

    private void OnChangeScene(string sceneName, bool addDelay)
    {
        if (addDelay)
        {
            SceneActions.CloseFader?.Invoke();
            StartCoroutine(StopWatch(()=>{
                SceneManager.LoadScene(sceneName);
            }));
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
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
}
