using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiAttack : EnnemisBaseState
{
    public EnemiAttack(EnnemisMovementSM ennemisStateMachine) : base("EnemiAttack", ennemisStateMachine) { }

    public float timeRemaining;

    public override void Enter()
    {
        base.Enter();

        timeRemaining = ennemisStateMachine.AttackDuration;

        //Animations
        ennemisStateMachine.EnnemiAnimator.SetBool("Walk", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Work", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Freeze", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Detect", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Attack", true);

        //UI
        ennemisStateMachine.DetectionStateIndicatorImage[0].color = ennemisStateMachine.Red;
        ennemisStateMachine.DetectionStateIndicatorImage[1].color = ennemisStateMachine.Red;
        ennemisStateMachine.DetectionStateIndicatorImage[2].color = ennemisStateMachine.Red;
        ennemisStateMachine.DetectionStateIndicatorImage[3].color = ennemisStateMachine.Red;
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        // Definir la position de fin du lerp comme etant celle de Laika
        var EndPos = new Vector3(ennemisStateMachine.LaikaPoint.x, ennemisStateMachine.transform.position.y, ennemisStateMachine.LaikaPoint.z);

        // Aller à la position de fin en 2 secondes
        ennemisStateMachine.transform.position = Vector3.Lerp(ennemisStateMachine.transform.position, EndPos, ennemisStateMachine.AttackDuration/2 * Time.deltaTime);

        if(timeRemaining > 0) timeRemaining -= Time.deltaTime;
        else if (timeRemaining <= 0) ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiPatroll);

    }
}
