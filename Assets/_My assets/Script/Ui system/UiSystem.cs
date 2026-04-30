using UnityEngine;
using System.Collections.Generic;

public class UiSystem : MonoBehaviour
{
    [SerializeField] private CanvasEnums defaultCanvas;
    [SerializeField] private List<GameObject> canvasList = new List<GameObject>();

    private void Start()
    {
        OnOpenCanvas(defaultCanvas);
    }

    private void OnEnable()
    {
        UiSystemActions.OpenCanvasAction += OnOpenCanvas;
        UiSystemActions.CloseCanvasAction += OnCloseCanvas;
    }

    private void OnDisable()
    {
        UiSystemActions.OpenCanvasAction -= OnOpenCanvas;
        UiSystemActions.CloseCanvasAction -= OnCloseCanvas;
    }

    private void OnOpenCanvas (CanvasEnums m_desireCanvas)
    {
        foreach (GameObject canvas in canvasList)
        {
            if (canvas.TryGetComponent(out ICanvasHandler c))
            {
                if(c.GetCanvasName() == m_desireCanvas) c.OpenCanvas();
                else c.CloseCanvas();
            }
        }
    }

    private void OnCloseCanvas(CanvasEnums m_desireCanvas)
    {
        foreach (GameObject canvas in canvasList)
        {
            if (canvas.TryGetComponent(out ICanvasHandler c))
            {
                c.CloseCanvas();
            }
        }
    }
}
