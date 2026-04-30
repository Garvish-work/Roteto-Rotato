public interface ICanvasHandler
{
    public void OpenCanvas();
    public void CloseCanvas();
    public CanvasEnums GetCanvasName();
}

public enum CanvasEnums
{
    MAIN_MENU,
    LEVEL_MENU,
    GAMEPLAY_CANVAS,
    LEVEL_COMPLETE_CANVAS,
    ALL_LEVEL_COMPLETED_CANVAS
}