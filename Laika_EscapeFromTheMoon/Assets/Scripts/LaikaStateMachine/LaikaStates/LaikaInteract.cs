using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaInteract : LaikaBaseState
{
    public LaikaInteract(LaikaMovementsSM laikaStateMachine) : base("LaikaInteract", laikaStateMachine) { }

    public float timeRemaining;

    public override void Enter()
    {
        base.Enter();
        // definir time rémaping comme égal à Intéractionduration de laikaStateMachine
        timeRemaining = laikaStateMachine.InteractionDuration;

        // jouer L'animation d'interaction
        laikaStateMachine.PlayInteractAnim();

        
       


    }


public override void UpdatePhysics()
{
    base.UpdatePhysics();

        Vector3 _direction = Vector3.Lerp(laikaStateMachine._laikaTransform.position, laikaStateMachine.InteractionTarget.position, 1f);
        laikaStateMachine._laikaRigidbody.MovePosition(_direction);
        //laikaStateMachine._laikaRigidbody.velocity = _direction;

    }


public override void UpdateLogic()
{
    base.UpdateLogic();

    //Si le temps qu'il reste est supérieur à zéro, lui soustraire le temps qui passe
    if (timeRemaining > 0)
    {
        timeRemaining -= Time.deltaTime;
    }
    //Si le temps qu'il reste est inférieur ou égal à zéro, sortir de cette state
    else if (timeRemaining <= 0)
    {
        laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaIdle);
    }
}
}
