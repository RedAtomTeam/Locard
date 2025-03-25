using UnityEngine;


public class InputHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _buttonForward;
    [SerializeField] private KeyCode _buttonLeft;
    [SerializeField] private KeyCode _buttonBackward;
    [SerializeField] private KeyCode _buttonRight;
    [SerializeField] private KeyCode _buttonUp;
    [SerializeField] private KeyCode _buttonDown;

    [SerializeField] private KeyCode _buttonRotateLeft;
    [SerializeField] private KeyCode _buttonRotateRight;

    [SerializeField] private Entity _controllable;
    public LevelController levelController;
    public CameraController cameraController;
    public float changeSpeedFieldOfView;

    public Entity Controllable
    {
        get
        {
            return this._controllable;
        }
        set
        {
            this._controllable = value;
        }
    }

    private void RotateButtonsLeft()
    {
        KeyCode btn = this._buttonForward;
        this._buttonForward = this._buttonLeft;
        this._buttonLeft = this._buttonBackward;
        this._buttonBackward = this._buttonRight;
        this._buttonRight = btn;
    }

    private void RotateButtonsRight()
    {
        KeyCode btn = this._buttonForward;
        this._buttonForward = this._buttonRight;
        this._buttonRight = this._buttonBackward;
        this._buttonBackward = this._buttonLeft;
        this._buttonLeft = btn;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            this.cameraController.CameraScroll(Input.GetAxis("Mouse ScrollWheel") * this.changeSpeedFieldOfView * Time.deltaTime * -1);
        }

        if (Input.GetKeyDown(this._buttonRotateLeft))
        {
            this.RotateButtonsLeft();
            this.cameraController.RotateLeft();
        }
        if (Input.GetKeyDown(this._buttonRotateRight))
        {
            this.RotateButtonsRight();
            this.cameraController.RotateRight();
        }

        if (Input.GetKeyDown(this._buttonForward))
        {
            this._controllable.HandleInput(Vector3Int.forward, this.levelController);
        }
        else if (Input.GetKeyDown(this._buttonBackward))
        {
            this._controllable.HandleInput(Vector3Int.back, this.levelController);
        }
        else if (Input.GetKeyDown(this._buttonLeft))
        {
            this._controllable.HandleInput(Vector3Int.left, this.levelController);
        }
        else if (Input.GetKeyDown(this._buttonRight))
        {
            this._controllable.HandleInput(Vector3Int.right, this.levelController);
        }
        else if (Input.GetKeyDown(this._buttonUp))
        {
            this._controllable.HandleInput(Vector3Int.up, this.levelController);
        }
        else if (Input.GetKeyDown(this._buttonDown))
        {
            this._controllable.HandleInput(Vector3Int.down, this.levelController);
        }
    }
}
