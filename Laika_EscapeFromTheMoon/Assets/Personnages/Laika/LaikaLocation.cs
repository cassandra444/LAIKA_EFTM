using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaLocation : MonoBehaviour
{
    InputManager _inputManager;

    private Vector3 _moveDirection;
    public Transform _cameraObject;
    public Rigidbody _laikaRigidbody;

    public float _movementSpeed = 7f;
    public float _rotationSpeed = 15f;

    void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _cameraObject = Camera.main.transform;
    }

    public void HandleAllMovements()
    {
        HandleMovements();
        HandleRotation();
    }

    private void HandleMovements()
    {
        //faire avancer le personnaage dans la direction que la camera regarde x la direction y du joystick/ZQSD
        _moveDirection = _cameraObject.forward * _inputManager._verticalInput;
        _moveDirection = _moveDirection + _cameraObject.right * _inputManager._horizontalInput;
        _moveDirection.Normalize();
        _moveDirection.y = 0f;
        _moveDirection = _moveDirection * _movementSpeed;

        Vector3 _movementVelocity = _moveDirection;
        _laikaRigidbody.velocity = _movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 _targetDirection = Vector3.zero;

        _targetDirection = _cameraObject.forward * _inputManager._verticalInput;
        _targetDirection = _targetDirection + _cameraObject.right * _inputManager._horizontalInput;
        _targetDirection.Normalize();
        _targetDirection.y = 0f;

        if (_targetDirection == Vector3.zero) _targetDirection = transform.forward;

        Quaternion _targetRotation = Quaternion.LookRotation(_targetDirection);
        Quaternion _laikaRotation = Quaternion.Slerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

        transform.rotation = _laikaRotation;
    }
}
