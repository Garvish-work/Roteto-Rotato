using UnityEngine;
using System.Collections.Generic;

public class LevelSpawnSystem : MonoBehaviour
{
    SaveSystem saveSystem;  

    [SerializeField] private int levelIndex;
    [SerializeField] private List<GameObject> levelList = new List<GameObject>();
    [SerializeField] private Transform levelSpawnHolder;
    [SerializeField] private LevelInfo spawnedLevelInfo;

    private void Start()
    {
        saveSystem = SaveSystem.instance;

        levelIndex = saveSystem.GetCurrentLevelIndex(); 
        if (levelIndex >= levelList.Count)
        {
            levelIndex = levelList.Count - 1;
        }
        GameObject spawnedLevel = Instantiate(levelList[levelIndex], Vector3.zero, Quaternion.identity, levelSpawnHolder);
        
        if (spawnedLevel.TryGetComponent(out ILevel l))
        {
            spawnedLevelInfo = l.GetLevelInfo();
            LevelSystemActions.LevelSpawned?.Invoke(spawnedLevelInfo);
        }
    }
}