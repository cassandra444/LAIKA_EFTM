using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiWork : EnnemisBaseState
{
    public EnemiWork(EnnemisMovementSM ennemisStateMachine) : base("EnemiWork", ennemisStateMachine) { }

    public float timeRemaining;

    public override void Enter()
    {
        base.Enter();

        //Definir la dur�e du timeur avant le changement de stte vers patrouille selon la valeur donn�e dans EnnemisStateMachine
        timeRemaining = ennemisStateMachine.WorkDuration;

        //Animations
        ennemisStateMachine.EnnemiAnimator.SetBool("Walk", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Work", true);
        ennemisStateMachine.EnnemiAnimator.SetBool("Freeze", false);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //Si le temps qu'il reste est sup�rieur � z�ro, lui soustraire le temps qui passe
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        //Si le temps qu'il reste est inf�rieur ou �gal � z�ro, sortir de cette state pour aller dans la state Patrouille
        else if (timeRemaining <= 0)
        {
            ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiPatroll);
        }

        if(ennemisStateMachine.EnnemiIsFreezed == true) ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiFreeze);
    }
}
