using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaInteract : LaikaBaseState
{
    public LaikaInteract(LaikaMovementsSM laikaStateMachine) : base("LaikaInteract", laikaStateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        laikaStateMachine.PlayInteractAnim();

        if (laikaStateMachine._interactInput == false)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaIdle);

        }

        /*if (laikaStateMachine._sprintInput == false)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaIdle);
        }*/
    }
}
