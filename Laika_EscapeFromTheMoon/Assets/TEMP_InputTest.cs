using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class TEMP_InputTest : MonoBehaviour
{
    [SerializeField] private InputActionReference mouvements, Attaque; 
    private Vector2 movInput;

    private void OnEnable()
    {
        Attaque.action.performed += PerformAttack;
    }

    private void OnDisable()
    {
        Attaque.action.performed -= PerformAttack;

    }

    private void PerformAttack(InputAction.CallbackContext obj)
    {
        Debug.Log("Attaque" );
    }


    void Update()
    {
        movInput = mouvements.action.ReadValue<Vector2>();
        //Debug.Log("mouvement v2 : " + movInput);
    }
}
