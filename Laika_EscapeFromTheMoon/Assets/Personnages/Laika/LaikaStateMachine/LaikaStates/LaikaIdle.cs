using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaIdle : LaikaBaseState
{

    public LaikaIdle(LaikaMovementsSM laikaStateMachine) : base("LaikaIdle", laikaStateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        laikaStateMachine.StopInteractAnim();
        laikaStateMachine.UpdateWalkAnimatorValue(0f, 0f, false);

        if (Mathf.Abs(laikaStateMachine._moveAmount) > Mathf.Epsilon)
        { 
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaWalk);

        }

        if (laikaStateMachine._interactInput == true)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaInteract);

        }

    }
}
