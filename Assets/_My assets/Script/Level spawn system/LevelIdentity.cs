using UnityEngine;

public class LevelIdentity : MonoBehaviour, ILevel
{
    [SerializeField] private LevelInfo levelInfo;

    public LevelInfo GetLevelInfo()
    {
        return levelInfo;
    }
}

public interface ILevel
{
    public LevelInfo GetLevelInfo();
}

[System.Serializable]
public class LevelInfo
{
    public float spaceRequried = 5;
}
