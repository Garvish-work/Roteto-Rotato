using TMPro;
using UnityEngine;

public class GameplayUiHandler : MonoBehaviour
{
    SaveSystem saveSystem;

    int levelIndex = 0;
    [SerializeField] private TMP_Text levelIndexText;
    [SerializeField] private AdsConfig adsConfig;

    private void Start()
    {
        saveSystem = SaveSystem.instance;
        AdsCounter();

        levelIndex = saveSystem.GetCurrentLevelIndex();
        if (levelIndex == 0) levelIndexText.text = "Tutorial";
        else levelIndexText.text = $"<size=50>Level</size>{levelIndex.ToString("00")}";
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

    private void AdsCounter()
    {
        adsConfig.playCount++;
        if (adsConfig.playCount >= adsConfig.maxPlayCount)
        {
            AdsAction.ShowInterstitialAds?.Invoke();
            adsConfig.playCount = 0;
        }
    }
}

