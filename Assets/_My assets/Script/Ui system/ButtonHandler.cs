using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();    
        button.onClick.AddListener(ButtonSfx);
    }

    private void ButtonSfx()
    {
        AudioActions.PlaySfx?.Invoke(SfxType.BUTTON);
    }
}
