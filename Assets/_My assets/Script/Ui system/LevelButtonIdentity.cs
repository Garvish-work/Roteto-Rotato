using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonIdentity : MonoBehaviour
{
    Button button;
    public int buttonIndex;
    SaveSystem saveSystem;
    Level levelInformation;

    [SerializeField] private LevelThumbnailData thumbnailData;
    [SerializeField] private Image levelThumbnail;
    [SerializeField] private GameObject[] lockGraphic;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        saveSystem = SaveSystem.instance;

        buttonIndex = transform.GetSiblingIndex();
        levelInformation = saveSystem.GetLevelInformation(buttonIndex);
        UpdateLevelUi();
    }

    private void UpdateLevelUi()
    {
        levelThumbnail.sprite = thumbnailData.levelSprite[buttonIndex];  
        switch (levelInformation.lockState)
        {
            case LockState.LOCKED:
                foreach (GameObject item in lockGraphic)
                {
                    item.SetActive(true);
                }
                break;
            case LockState.UNLOKCED:
                foreach (GameObject item in lockGraphic)
                {
                    item.SetActive(false);
                }
                button.onClick.AddListener(OnClickEvent);
                break;
        }

    }

    private void OnClickEvent()
    {
        saveSystem.SetCurrentLevel(buttonIndex);    
        SceneActions.ChangeScene?.Invoke("GAMEPLAY SCENE", true);
    }
}
