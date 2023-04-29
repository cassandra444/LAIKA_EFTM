using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaSprint : LaikaBaseState
{
    public LaikaSprint(LaikaMovementsSM laikaStateMachine) : base("LaikaSprint", laikaStateMachine) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        laikaStateMachine.HandleMovements(laikaStateMachine._sprintingSpeed);
        laikaStateMachine.HandleRotation();
        laikaStateMachine.UpdateSprintAnimatorValue(2f, 2f, true);


        if (laikaStateMachine._sprintInput == false)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaWalk);
        }

        if (laikaStateMachine._interactInput == true && laikaStateMachine.InteractionTarget != null)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaInteract);

        }
    }
}
