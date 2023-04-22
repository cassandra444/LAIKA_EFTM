using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaWalk : LaikaBaseState
{

    public LaikaWalk(LaikaMovementsSM laikaStateMachine) : base("LaikaWalk", laikaStateMachine) { }

    public override void Enter()
    {
        base.Enter();

    }

    //laikaStateMachine.UpdateAnimatorValue();

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        #region Movements
        laikaStateMachine._moveDirection = laikaStateMachine._cameraObject.forward * laikaStateMachine._verticalInput;
        laikaStateMachine._moveDirection = laikaStateMachine._moveDirection + laikaStateMachine._cameraObject.right * laikaStateMachine._horizontalInput;
        laikaStateMachine._moveDirection.Normalize();
        laikaStateMachine._moveDirection.y = 0f;

        Vector3 _movementVelocity = laikaStateMachine._moveDirection;
        laikaStateMachine._laikaRigidbody.velocity = _movementVelocity;
        laikaStateMachine._moveDirection = laikaStateMachine._moveDirection * laikaStateMachine._walkingSpeed;

        Vector3 _targetDirection = Vector3.zero;

        _targetDirection = laikaStateMachine._cameraObject.forward * laikaStateMachine._verticalInput;
        _targetDirection = _targetDirection + laikaStateMachine._cameraObject.right * laikaStateMachine._horizontalInput;
        _targetDirection.Normalize();
        _targetDirection.y = 0f;

        if (_targetDirection == Vector3.zero) _targetDirection = laikaStateMachine._laikaTransform.forward;

        Quaternion _targetRotation = Quaternion.LookRotation(_targetDirection);
        Quaternion _laikaRotation = Quaternion.Slerp(laikaStateMachine._laikaTransform.rotation, _targetRotation, laikaStateMachine._rotationSpeed * Time.deltaTime);

        laikaStateMachine._laikaTransform.rotation = _laikaRotation;
        #endregion

        #region Animations
        laikaStateMachine.UpdateWalkAnimatorValue(0f, laikaStateMachine._moveAmount, false);

        #endregion
        #region Change State
        if (Mathf.Abs(laikaStateMachine._moveAmount) < Mathf.Epsilon)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaIdle);     
        }

        if(laikaStateMachine._sprintInput == true)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaSprint);
        }

        if (laikaStateMachine._interactInput == true)
        {
            laikaStateMachine.ChangeState(((LaikaMovementsSM)laikaStateMachine).laikaInteract);

        }
        #endregion
    }
}
