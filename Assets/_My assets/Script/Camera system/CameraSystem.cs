using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    Camera mainCamera;
    LevelInfo spawnedLevelInfo;

    private void Awake() => mainCamera = Camera.main;

    private void OnEnable()
    {
        LevelSystemActions.LevelSpawned += OnLevelSpawned;
    }

    private void OnDisable()
    {
        LevelSystemActions.LevelSpawned -= OnLevelSpawned;
    }

    private void OnLevelSpawned(LevelInfo m_levelInfo)
    {
        float m_levelZoomValue = m_levelInfo.spaceRequried;
        SetCameraZoom(m_levelZoomValue);
    }

    private void SetCameraZoom(float m_zoomValue)
    {
        mainCamera.orthographicSize = m_zoomValue;
    }
}
