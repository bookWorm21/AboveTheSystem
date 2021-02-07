using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;
    [SerializeField] private QualiferPlatform _qualifer;
    [Space(order = 20)]
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    [Space(order = 20)]
    [SerializeField] private float _maxX;
    [SerializeField] private float _minX;
    [Space(order = 10)]
    [SerializeField] private float _maxZ;
    [SerializeField] private float _minZ;
    [Space(order = 20)]

    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _comingSpeed;

    private float _movingSpeed;

    private IInputForCamera _inputing;
    private Vector3 _inputMoving;
    private Vector3 _moving;
    private Vector3 _nextPosition;

    private float _currentHeight;
    private float _startHeight;

    private float _sin;
    private float _cos;

    private void Start()
    {
        _inputing = _qualifer.GetCurrentInput();
        _sin = (float)System.Math.Sin((-1f) * transform.eulerAngles.y * System.Math.PI / 180);
        _cos = (float)System.Math.Cos((-1f) * transform.eulerAngles.y * System.Math.PI / 180);

        _movingSpeed = _defaultSpeed;
        _currentHeight = transform.position.y;
        _startHeight = _currentHeight;
    }

    private void LateUpdate()
    {
        if (_placeLogic.IsSelected == false)
        {
            _inputMoving = _inputing.GetDeltaPosition();
            _moving = Vector3.zero;
            _moving.x = _inputMoving.x * _cos + (-1f) * _inputMoving.z * _sin;
            _moving.z = _inputMoving.x * _sin + _inputMoving.z * _cos;

            _nextPosition = transform.position - _moving;
            _nextPosition.x = Mathf.Clamp(_nextPosition.x, _minX, _maxX);
            _nextPosition.z = Mathf.Clamp(_nextPosition.z, _minZ, _maxZ);

            transform.position = Vector3.MoveTowards(transform.position,
                                                     _nextPosition,
                                                     _movingSpeed * Time.deltaTime);

            _currentHeight -= _inputing.GetExtensionValue();
            _currentHeight = Mathf.Clamp(_currentHeight, _minHeight, _maxHeight);
            _moving = transform.position;
            _moving.y = _currentHeight;
            _movingSpeed = _defaultSpeed * _currentHeight / _startHeight;
            transform.position = Vector3.MoveTowards(transform.position,
                                                     _moving,
                                                     _comingSpeed * Time.deltaTime);
        }
    }
}
