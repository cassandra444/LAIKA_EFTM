using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaManager : MonoBehaviour
{
    InputManager _inputManager;
    public CameraManager _cameraManager;
    LaikaLocation _laikaLocation;
    public bool _laikaIsInFreezeRange;
    public bool _laikaCanFreeze;

    private void Awake()
    {
        //_laikaIsInFreezeRange = false;
        _inputManager = GetComponent<InputManager>();
        _laikaLocation = GetComponent<LaikaLocation>();
    }

    private void Update()
    {
        _inputManager.HandleAllInputs();

        if (_laikaIsInFreezeRange) _laikaCanFreeze = true;
        else _laikaCanFreeze = false;
    }

    private void FixedUpdate()
    {
        _laikaLocation.HandleAllMovements();
    }

    private void LateUpdate()
    {
        _cameraManager.HandleAllCameraMovements();
        
    }

}
