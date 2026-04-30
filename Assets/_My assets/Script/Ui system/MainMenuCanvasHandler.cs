using UnityEngine;

public class MainMenuCanvasHandler : MonoBehaviour
{
    public void B_OpenLevel()
    {
        UiSystemActions.OpenCanvasAction(CanvasEnums.LEVEL_MENU);
    }

    public void B_OpenMainMenu()
    {
        UiSystemActions.OpenCanvasAction(CanvasEnums.MAIN_MENU);
    }

    public void B_Resume()
    {
        SceneActions.ChangeScene("GAMEPLAY SCENE", true);
    }
}
