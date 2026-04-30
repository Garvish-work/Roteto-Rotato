using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public void B_Enter()
    {
        InputSystemActions.ScreenPressed?.Invoke(true);
    }

    public void B_Exit()
    { 
        InputSystemActions.ScreenPressed?.Invoke(false);
    }
}
