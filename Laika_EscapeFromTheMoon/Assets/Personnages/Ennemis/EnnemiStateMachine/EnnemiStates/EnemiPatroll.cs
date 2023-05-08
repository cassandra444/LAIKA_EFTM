using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiPatroll : EnnemisBaseState
{
    public EnemiPatroll(EnnemisMovementSM ennemisStateMachine) : base("EnemiPatroll", ennemisStateMachine) { }

    public override void Enter()
    {
        base.Enter();
        //UI State
        ennemisStateMachine.DetectionStateIndicatorImage[0].color = ennemisStateMachine.Blue;
        ennemisStateMachine.DetectionStateIndicatorImage[1].color = ennemisStateMachine.Blue;
        ennemisStateMachine.DetectionStateIndicatorImage[2].color = ennemisStateMachine.Blue;
        ennemisStateMachine.DetectionStateIndicatorImage[3].color = ennemisStateMachine.Blue;

        //Animations
        ennemisStateMachine.EnnemiAnimator.SetBool("Walk", true);
        ennemisStateMachine.EnnemiAnimator.SetBool("Work", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Freeze", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Detect", false);
        ennemisStateMachine.EnnemiAnimator.SetBool("Attack", false);

        //Passer au point suivant dans le tableau de points
        ennemisStateMachine.CurrentWaypointIndex = (ennemisStateMachine.CurrentWaypointIndex + 1) % ennemisStateMachine.EnnemiPatrollPointArr.Length;
    }
    

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        //Version transform : Deplacer l'ennemi de sont point actuel au point suivant
        ennemisStateMachine.EnnemiTransform.transform.position = 
        Vector3.MoveTowards(ennemisStateMachine.EnnemiTransform.transform.position, 
        ennemisStateMachine.EnnemiPatrollPointArr[ennemisStateMachine.CurrentWaypointIndex].position, 
        ennemisStateMachine.PatrollSpeed * Time.deltaTime);

        //Version AddForce : Deplacer l'ennemi de sont point actuel au point suivant
        //ennemisStateMachine.EnnemiRB.AddForce(ennemisStateMachine.EnnemiPatrollPointArr[ennemisStateMachine.CurrentWaypointIndex].position * ennemisStateMachine.PatrollSpeed);

        //rotation : Se tourner dans la direction du point suivant
        ennemisStateMachine.EnnemiTransform.transform.LookAt(ennemisStateMachine.EnnemiPatrollPointArr[ennemisStateMachine.CurrentWaypointIndex].position);

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        //Si l'ennemis est à la même positin que le point visé alors changer de state pour Work
        if(Vector3.Distance(ennemisStateMachine.EnnemiTransform.transform.position, ennemisStateMachine.EnnemiPatrollPointArr[ennemisStateMachine.CurrentWaypointIndex].position) <= 0.01f)
        {
            ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiWork);
        }

        if (ennemisStateMachine.EnnemiIsFreezed == true) ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiFreeze);

        if (ennemisStateMachine.LaikaInDetectionRange) ennemisStateMachine.ChangeState(((EnnemisMovementSM)ennemisStateMachine).enemiDetect);
    }
}
