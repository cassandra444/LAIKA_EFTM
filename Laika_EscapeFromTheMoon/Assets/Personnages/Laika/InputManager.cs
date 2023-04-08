using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputActionLEFTM _laikaControls;
    public LaikaAnimation _laikaAnimation;

    public Vector2 _mouvementInput;
    public Vector2 _cameraInput;


    private float _moveAmount;
    public float _verticalInput;
    public float _horizontalInput;
    public float _cameraInputX;
    public float _cameraInputY;



    private void OnEnable()
    {
        if(_laikaControls == null)
        {
            _laikaControls = new InputActionLEFTM();
            _laikaControls.LaikaInput.Mouvements.performed += i => _mouvementInput = i.ReadValue<Vector2>();
            _laikaControls.LaikaInput.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
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
    }

    private void HandleMovementsInput()
    {
        _verticalInput = _mouvementInput.y;
        _horizontalInput = _mouvementInput.x;

        _cameraInputX = _cameraInput.x;
        _cameraInputY = _cameraInput.y;

        _moveAmount = Mathf.Clamp01(Mathf.Abs(_horizontalInput) + Mathf.Abs(_verticalInput));
        _laikaAnimation.UpdateAnimatorValue( 0f, _moveAmount);
    }
}
