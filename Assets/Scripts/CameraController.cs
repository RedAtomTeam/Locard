using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;
    [SerializeField] private Camera _cam;

    private Vector3 _targetRotation;
    private Tween _currentTween;  

    public float minFieldOfView;
    public float maxFieldOfView;


    private void Start()
    {
        this._targetRotation = this.transform.rotation.eulerAngles;
    }


    private void Update()
    {
        var var1 = this.transform.position;
        var var2 = this._inputHandler.Controllable.transform.position + this._offset;
        var var3 = Time.deltaTime * this._speed;


        var nextPosition = Vector3.Lerp(this.transform.position, this._inputHandler.Controllable.transform.position + this._offset, Time.deltaTime * this._speed);
        this.transform.position = nextPosition;   
    }


    public void CameraScroll(float scrollValue)
    {
        float finallFieldOfView = this._cam.fieldOfView + scrollValue;    
        if (finallFieldOfView > this.maxFieldOfView) 
        {
            finallFieldOfView = this.maxFieldOfView;
        }
        if (finallFieldOfView < this.minFieldOfView)
        {
            finallFieldOfView = this.minFieldOfView;
        }
        this._cam.fieldOfView = finallFieldOfView;
    }


    public void RotateLeft()
    {
        this._targetRotation += new Vector3(0, 90, 0);
        this._currentTween?.Kill();
        this._currentTween = this.gameObject.transform.DORotate(this._targetRotation, 0.5f)
            .SetEase(Ease.InOutSine);
    }


    public void RotateRight()
    {
        this._targetRotation += new Vector3(0, -90, 0);
        this._currentTween?.Kill();
        this._currentTween = this.gameObject.transform.DORotate(this._targetRotation, 0.5f)
            .SetEase(Ease.InOutSine);
    }
}
