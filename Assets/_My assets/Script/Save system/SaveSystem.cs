using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    [SerializeField] private string saveLocation = string.Empty;
    string jsonString = string.Empty;
    [SerializeField] private GameData gameData;

    private void Awake()
    {
        // Singleton Pattern - Makes sure only ONE instance exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        saveLocation = Path.Combine(Application.persistentDataPath, "GameData.json");

        LoadGameData();
    }

    private void OnEnable()
    {
        LevelActions.LevelCompleted += SetLevelUnlock;
    }

    private void OnDisable()
    {
        LevelActions.LevelCompleted -= SetLevelUnlock;
    }

    private void LoadGameData()
    {
        if (!File.Exists(saveLocation))
        {
            Debug.Log("Save file not found");
            SaveGameData();
        }

        string json = File.ReadAllText(saveLocation);
        gameData = JsonUtility.FromJson<GameData>(json);
    }

    private void SaveGameData()
    {
        jsonString = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(saveLocation, jsonString);

        Debug.Log("Saved at: " + saveLocation);
    }

    // Set functions
    public void SetCurrentLevel(int levelIndex)
    {
        gameData.currentLevelIndex = levelIndex;    
    }

    public void SetLevelUnlock()
    {
        int currentLevel = gameData.currentLevelIndex;
        if (!gameData.levels[currentLevel].isLastLevel)
        {
            gameData.levels[currentLevel + 1].lockState = LockState.UNLOKCED;
            gameData.currentLevelIndex++;   
            SaveGameData();
        }
    }

    // Get functions
    public Level GetLevelInformation(int levelIndex)
    {
        return gameData.levels[levelIndex]; 
    }

    public int GetCurrentLevelIndex()
    {
        return gameData.currentLevelIndex;  
    }
}

[System.Serializable]
public class GameData
{
    public int currentLevelIndex = 0;
    public Level[] levels;
}

[System.Serializable]
public class Level
{
    public string name;
    public int index;
    public LockState lockState;
    public CompleteState completeState;
    public bool isLastLevel = false;
}

public enum LockState
{
    LOCKED,
    UNLOKCED
}

public enum CompleteState
{
    INCOMPLETE,
    COMPLETE
}
