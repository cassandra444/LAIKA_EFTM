using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    InputActionLEFTM laikaControls;
    [SerializeField] private Vector2 _mouvementInput;


    private void OnEnable()
    {
        if(laikaControls == null)
        {
            laikaControls = new InputActionLEFTM();
            laikaControls.LaikaInput.Mouvements.performed += i => _mouvementInput = i.ReadValue<Vector2>();
        }

        laikaControls.Enable();
    }

    private void OnDisable()
    {
        laikaControls.Disable();
    }

    private void PerformAttack()
    {
        Debug.Log("Attaque");
    }
}
