using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiFreeze : EnnemisBaseState
{
    public EnemiFreeze(EnnemisMovementSM ennemisStateMachine) : base("EnemiFreeze", ennemisStateMachine) { }

    public float timeRemaining;

    public override void Enter()
    {
        base.Enter();
        // definir time rémaping comme égal à Intéractionduration de laikaStateMachine
        timeRemaining = ennemisStateMachine.FreezeDuration;

        //Animations
        ennemisStateMachine.EnnemiAnimator.SetBool("Walk", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Work", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Freeze", true);
        

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
            ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiPatroll);
        }
    }
}
