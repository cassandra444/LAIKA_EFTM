using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaLocation : MonoBehaviour
{

#region Variables
    InputManager _inputManager;
    LaikaManager _laikaManager;

    [Header("References")]
    private Vector3 _moveDirection;
    public Transform _cameraObject;
    public Rigidbody _laikaRigidbody;

    [Header("Movements Parameters")]
    public bool _isSprinting;
    public float _walkingSpeed = 1.5f;
    public float _sprintingSpeed = 7f;
    public float _runningSpeed = 5f;
    public float _rotationSpeed = 15f;
    

    [Header("Attack Parameters")]
    public bool _isAttacking;
    public bool _attckCoolDown;
    public float _AttackCoolDown = 5f;
#endregion

    void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _laikaManager = GetComponent<LaikaManager>();
        _cameraObject = Camera.main.transform;
    }

#region Fonctions de déplacements
    public void HandleAllMovements()
    {
        HandleMovements();
        HandleRotation();
        HandleAttack();
    }

    private void HandleMovements()
    {
        //faire avancer le personnaage dans la direction que la camera regarde x la direction y du joystick/ZQSD
        _moveDirection = _cameraObject.forward * _inputManager._verticalInput;
        _moveDirection = _moveDirection + _cameraObject.right * _inputManager._horizontalInput;
        _moveDirection.Normalize();
        _moveDirection.y = 0f;
        //_moveDirection = _moveDirection * _movementSpeed;

        if (_isSprinting)
        {
            _moveDirection = _moveDirection * _sprintingSpeed;
        }
        else
        {
            if (_inputManager._moveAmount >= 0.5f) _moveDirection = _moveDirection * _runningSpeed;
            else _moveDirection = _moveDirection * _walkingSpeed;
        }

       

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
#endregion

#region Fonction d'attaque
    private IEnumerator AttackCoolDown()
    {
        _attckCoolDown = true;
        yield return new WaitForSeconds(_AttackCoolDown);
        _attckCoolDown = false;
    }

    private void HandleAttack()
    {
        if (_laikaManager._laikaCanFreeze)
        {
            if (_isAttacking && _attckCoolDown == false)
            {
                Debug.Log("Laika Attack");
                StartCoroutine("AttackCoolDown");
            }
                
        }
        
    }

#endregion

}
