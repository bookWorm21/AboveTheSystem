using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;
    [SerializeField] private QualiferPlatform _qualifer;
    [SerializeField] private float _minSquareValueInAxis;
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
        _nextPosition = transform.position;
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

            Vector3 currentVelocity = -_moving * _movingSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, _nextPosition, ref currentVelocity, 0.05f , _movingSpeed);

            _currentHeight -= _inputing.GetExtensionValue();
            _currentHeight = Mathf.Clamp(_currentHeight, _minHeight, _maxHeight);
            _moving = transform.position;
            _moving.y = _currentHeight;
            float k = _currentHeight / _startHeight;

            if(_currentHeight > _startHeight)
            {
                k *= (1 + (_currentHeight - _startHeight) / 2.5f);
            }

            _movingSpeed = _defaultSpeed * k * k;
            _movingSpeed = Mathf.RoundToInt(_movingSpeed);
            transform.position = Vector3.MoveTowards(transform.position,
                                                     _moving,
                                                     _comingSpeed * Time.deltaTime);
        }
    }
}
