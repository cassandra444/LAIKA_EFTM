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
        // definir time r�maping comme �gal � Int�ractionduration de laikaStateMachine
        timeRemaining = laikaStateMachine.InteractionDuration;

        // jouer L'animation d'interaction
        laikaStateMachine.PlayInteractAnim();

         // Pour l'instant, nique la physique.
         laikaStateMachine._laikaTransform.position = laikaStateMachine.InteractionTarget.position;
       


    }

   
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //Si le temps qu'il reste est sup�rieur � z�ro, lui soustraire le temps qui passe
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        //Si le temps qu'il reste est inf�rieur ou �gal � z�ro, sortir de cette state
        else if (timeRemaining <= 0)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaIdle);
        }
    }
}
