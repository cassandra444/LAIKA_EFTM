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
        //UI State
        ennemisStateMachine.DetectionStateIndicatorImage[0].color = ennemisStateMachine.Blue;
        ennemisStateMachine.DetectionStateIndicatorImage[1].color = ennemisStateMachine.Blue;
        ennemisStateMachine.DetectionStateIndicatorImage[2].color = ennemisStateMachine.Blue;
        ennemisStateMachine.DetectionStateIndicatorImage[3].color = ennemisStateMachine.Blue;

        // definir time r�maping comme �gal � Int�ractionduration de laikaStateMachine
        timeRemaining = ennemisStateMachine.FreezeDuration;

        //Animations
        ennemisStateMachine.EnnemiAnimator.SetBool("Walk", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Work", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Freeze", true);
        ennemisStateMachine.EnnemiAnimator.SetBool("Detect", false);

        //Emissive Color
        ennemisStateMachine.EnnemiRend.material.SetColor("_EmissiveColor", ennemisStateMachine.EmissiveBlue);

        //Rig
        ennemisStateMachine.EnnemiRig.weight = 0f;


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
            ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiPatroll);
        }
    }
}
