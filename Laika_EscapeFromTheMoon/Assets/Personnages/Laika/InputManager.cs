using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputActionLEFTM _laikaControls;
    public LaikaAnimation _laikaAnimation;
    public LaikaLocation _laikaLocation;

    public Vector2 _mouvementInput;
    public Vector2 _cameraInput;


    public float _moveAmount;
    public float _verticalInput;
    public float _horizontalInput;
    public float _cameraInputX;
    public float _cameraInputY;

    public bool _sprintInput;



    private void OnEnable()
    {
        if(_laikaControls == null)
        {
            _laikaControls = new InputActionLEFTM();
            _laikaControls.LaikaMovements.Mouvements.performed += i => _mouvementInput = i.ReadValue<Vector2>();
            _laikaControls.LaikaMovements.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();

            _laikaControls.LaikaActions.SprintButton.performed += i => _sprintInput = true;
            _laikaControls.LaikaActions.SprintButton.canceled += i => _sprintInput = false;
        }

        _laikaControls.Enable();
    }

    private void OnDisable()
    {
        _laikaControls.Disable();
    }

    private void PerformAttack()
    {
        Debug.Log("Attaque");
    }

    public void HandleAllInputs()
    {
        HandleMovementsInput();
        HandleSprintingInput();
    }

    private void HandleMovementsInput()
    {
        _verticalInput = _mouvementInput.y;
        _horizontalInput = _mouvementInput.x;

        _cameraInputX = _cameraInput.x;
        _cameraInputY = _cameraInput.y;

        _moveAmount = Mathf.Clamp01(Mathf.Abs(_horizontalInput) + Mathf.Abs(_verticalInput));
        _laikaAnimation.UpdateAnimatorValue( 0f, _moveAmount, _laikaLocation._isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (_sprintInput && _moveAmount > 0.5f) _laikaLocation._isSprinting = true;
        else _laikaLocation._isSprinting = false;
    }
}
