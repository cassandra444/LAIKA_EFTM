using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaManager : MonoBehaviour
{
    InputManager _inputManager;
    public CameraManager _cameraManager;
    LaikaLocation _laikaLocation;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _laikaLocation = GetComponent<LaikaLocation>();
    }

    private void Update()
    {
        _inputManager.HandleAllInputs();
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
