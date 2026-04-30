using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonIdentity : MonoBehaviour
{
    Button button;
    public int buttonIndex;
    SaveSystem saveSystem;
    Level levelInformation;

    [SerializeField] private GameObject[] lockGraphic;
    [SerializeField] private TMP_Text levelNameText;

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
        if (buttonIndex == 0) levelNameText.text = "TUTO\nRIAL";
        else levelNameText.text = "LEVEL \n<SIZE=60><color=#373737>" + buttonIndex.ToString("00");

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
