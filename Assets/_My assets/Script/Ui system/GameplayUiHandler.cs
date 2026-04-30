using TMPro;
using UnityEngine;

public class GameplayUiHandler : MonoBehaviour
{
    SaveSystem saveSystem;

    int levelIndex = 0;
    [SerializeField] private TMP_Text levelIndexText;

    private void Start()
    {
        saveSystem = SaveSystem.instance;

        levelIndex = saveSystem.GetCurrentLevelIndex();
        if (levelIndex == 0) levelIndexText.text = "TUTORIAL";
        else levelIndexText.text = $"<color=#E3E3E3>Level</color><b> {levelIndex.ToString("00")}";
    }

    private void OnEnable()
    {
        LevelActions.LevelCompleted += OnLevelCompleted;
    }

    private void OnDisable()
    {
        LevelActions.LevelCompleted -= OnLevelCompleted;
    }

    public void B_Restart()
    {
        SceneActions.ChangeScene("GAMEPLAY SCENE", true);
    }

    public void B_NextLevel()
    {
        SceneActions.ChangeScene("GAMEPLAY SCENE", true);
    }

    public void B_Home()
    {
        SceneActions.ChangeScene("MAIN MENU SCENE", true);
    }

    private void OnLevelCompleted()
    {
        Level levelInformation = saveSystem.GetLevelInformation(levelIndex);

        if (!levelInformation.isLastLevel) UiSystemActions.OpenCanvasAction(CanvasEnums.LEVEL_COMPLETE_CANVAS);
        else UiSystemActions.OpenCanvasAction(CanvasEnums.ALL_LEVEL_COMPLETED_CANVAS);    
    }
}

