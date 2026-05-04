using UnityEngine;

public class SlpashScreenHandler : MonoBehaviour
{
    [SerializeField] private float timeToChange = 10;

    private void Start()
    {
        Invoke(nameof(changeScene), timeToChange);   
    }

    private void changeScene()
    {
        SceneActions.ChangeScene ("MAIN MENU SCENE", false);    
    }
}
