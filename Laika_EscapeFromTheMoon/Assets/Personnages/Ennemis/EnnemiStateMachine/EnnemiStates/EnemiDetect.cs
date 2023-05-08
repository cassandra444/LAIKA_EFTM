using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiDetect : EnnemisBaseState
{
    public EnemiDetect(EnnemisMovementSM ennemisStateMachine) : base("EnemiDetect", ennemisStateMachine) { }

    public float timeRemaining;

    public override void Enter()
    {
        base.Enter();

        timeRemaining = ennemisStateMachine.DetecDuration;

        //Animations
        ennemisStateMachine.EnnemiAnimator.SetBool("Walk", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Work", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Freeze", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Detect", true);

        //UI
        ennemisStateMachine.DetectionStateIndicatorImage[0].color = ennemisStateMachine.Yellow;
        ennemisStateMachine.DetectionStateIndicatorImage[1].color = ennemisStateMachine.Yellow;
        ennemisStateMachine.DetectionStateIndicatorImage[2].color = ennemisStateMachine.Yellow;
        ennemisStateMachine.DetectionStateIndicatorImage[3].color = ennemisStateMachine.Yellow;

        //ennemisStateMachine.transform.LookAt(new Vector3(ennemisStateMachine.LaikaPoint.x, ennemisStateMachine.LaikaPoint.y * -1, ennemisStateMachine.LaikaPoint.z));


    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            ennemisStateMachine.transform.LookAt (new Vector3(ennemisStateMachine.LaikaPoint.x, ennemisStateMachine.LaikaPoint.y * -0.5f, ennemisStateMachine.LaikaPoint.z));
        }

        //Si l'ennemi est toujours en detection et qu'il detecte laika
        //ALORS Changer de state vers la state Attack
        if (timeRemaining <= 0 && ennemisStateMachine.LaikaInDetectionRange == true)
        {
            ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiAttack);
        }

        //Si l'ennemi est toujours en detection et qu'il ne detecte pa laika
        //ALORS Changer de state vers la state Patroll
        else if (timeRemaining <= 0 && ennemisStateMachine.LaikaInDetectionRange == false)
        {
            ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiPatroll);
        }
        
    }

}

