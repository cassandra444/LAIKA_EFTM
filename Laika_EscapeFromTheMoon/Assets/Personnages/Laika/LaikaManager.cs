using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaManager : MonoBehaviour
{
    InputManager _inputManager;
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

}
