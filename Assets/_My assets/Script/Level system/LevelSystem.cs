using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    float input = 1;
    [SerializeField] private LevelData levelData;

    private void OnEnable()
    {
        InputSystemActions.ScreenPressed += OnScreenPressed;
    }

    private void OnDisable()
    {
        InputSystemActions.ScreenPressed -= OnScreenPressed;
    }

    private void OnScreenPressed(bool pressed)
    {
        if (pressed) input = -1;
        else if (!pressed) input = 1;
    }


    void Update()
    {
        transform.Rotate(0, 0, levelData.levelSpeed * input * Time.deltaTime);
    }   
}
