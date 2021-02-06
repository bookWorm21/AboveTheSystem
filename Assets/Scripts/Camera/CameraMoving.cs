using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;
    [SerializeField] private QualiferPlatform _qualifer;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _comingSpeed;

    private IInputForCamera _inputing;
    private Vector3 _inputMoving;
    private Vector3 _moving;

    private float _currentHeight;

    private float _sin;
    private float _cos;

    private void Start()
    {
        _inputing = _qualifer.GetCurrentInput();
        _sin = (float)System.Math.Sin((-1f) * transform.eulerAngles.y * System.Math.PI / 180);
        _cos = (float)System.Math.Cos((-1f) * transform.eulerAngles.y * System.Math.PI / 180);

        _currentHeight = transform.position.y;
    }

    private void LateUpdate()
    {
        if (_placeLogic.IsSelected == false)
        {
            _inputMoving = _inputing.GetDeltaPosition();
            _moving = Vector3.zero;
            _moving.x = _inputMoving.x * _cos + (-1f) * _inputMoving.z * _sin;
            _moving.z = _inputMoving.x * _sin + _inputMoving.z * _cos;
            transform.position = Vector3.MoveTowards(transform.position,
                                                     transform.position - _moving,
                                                     _movingSpeed * Time.deltaTime);

            _currentHeight -= _inputing.GetExtensionValue();
            _currentHeight = Mathf.Clamp(_currentHeight, _minHeight, _maxHeight);
            _moving = transform.position;
            _moving.y = _currentHeight;
            transform.position = Vector3.MoveTowards(transform.position,
                                                     _moving,
                                                     _comingSpeed * Time.deltaTime);
        }
    }
}
