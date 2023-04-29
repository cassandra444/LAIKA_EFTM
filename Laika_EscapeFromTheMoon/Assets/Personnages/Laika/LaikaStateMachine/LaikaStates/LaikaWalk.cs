using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaWalk : LaikaBaseState
{

    public LaikaWalk(LaikaMovementsSM laikaStateMachine) : base("LaikaWalk", laikaStateMachine) { }

    public override void Enter()
    {
        base.Enter();

    }



    public override void UpdateLogic()
    {
        base.UpdateLogic();
        laikaStateMachine.HandleMovements(laikaStateMachine._walkingSpeed);
        laikaStateMachine.HandleRotation();

        #region Animations
        laikaStateMachine.UpdateWalkAnimatorValue(0f, laikaStateMachine._moveAmount, false);

        #endregion
        #region Change State
        if (Mathf.Abs(laikaStateMachine._moveAmount) < Mathf.Epsilon)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaIdle);     
        }

        if(laikaStateMachine._sprintInput == true)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaSprint);
        }

        if (laikaStateMachine._interactInput == true && laikaStateMachine.InteractionTarget != null)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaInteract);

        }
        #endregion
    }
}
