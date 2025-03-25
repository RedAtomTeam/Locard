

public class Context
{
    public LevelController _levelController;
    public LevelGrid _levelGrid;
    public InputHandler _inputHandler;

    public Context(LevelController levelController, LevelGrid levelGrid, InputHandler inputHandler)
    {
        this._levelController = levelController;
        this._levelGrid = levelGrid;
        this._inputHandler = inputHandler;
    }
}
