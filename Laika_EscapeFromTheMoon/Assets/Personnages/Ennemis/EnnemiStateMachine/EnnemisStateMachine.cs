using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnnemisStateMachine : MonoBehaviour
{
    #region State Machine


    EnnemisBaseState currentState;
    [Header("State Machine")]
    public TextMeshProUGUI _stateText;


    void Start()
    {

        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();

    }

    void Update()
    {
        _stateText.text = currentState.name;

        if (currentState != null)
            currentState.UpdateLogic();

        if (freezeRangeChecker.LaikaIsInFreezeRange == true && laikaStateMachine.currentState.name == "LaikaInteract") EnnemiIsFreezed = true;
        //pas sure de ça
        else EnnemiIsFreezed = false;

    }

    void LateUpdate()
    {

        if (currentState != null)
            currentState.UpdatePhysics();

    }

    protected virtual EnnemisBaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(EnnemisBaseState newState)
    {

        currentState.Exit();

        currentState = newState;
        currentState.Enter();

    }

    #endregion

    #region Work / Patroll

    [Header("Bases")]
    public Rigidbody EnnemiRB;
    public Transform EnnemiTransform;
    public Animator EnnemiAnimator;

    [Header(" Work")]
    public float WorkDuration;

    [Header(" Patroll")]
    public Transform[] EnnemiPatrollPointArr;
    public int CurrentWaypointIndex = 0;
    public float PatrollSpeed;

    #endregion

    #region Freeze

    [Header("Freeze")]
    public float FreezeDuration;
    public FreezeRangeChecker freezeRangeChecker;
    public LaikaStateMachine laikaStateMachine;
    public bool EnnemiIsFreezed;

    #endregion
}
