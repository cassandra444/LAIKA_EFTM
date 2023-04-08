using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public InputManager _inputManager;
    public Transform _targetTransform;
    public Transform _cameraPivot;
    private float _defaultPosition;
    public Transform _cameraTransform;
    public LayerMask _collisionLayers;

    private Vector3 _cameraFollowVelocity = Vector3.zero;
    private Vector3 _cameraVectorPosition; 

    public float _cameraFollowSpeed = 0.2f;
    public float _cameraLookSpeed = 2f;
    public float _cameraPivotSpeed = 2f;
    public float _minimumPivotAngle = -35f;
    public float _maximumPivotAngle = 35f;
    public float _cameraCollisionRadius = 2f;
    public float _cameraCollisionOffset = 0.2f;
    public float _minimumCollisionOffset = 0.2f;


    public float _lookAngle;
    public float _pivotAngle;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
        _defaultPosition = _cameraTransform.localPosition.z;
    }

    public void HandleAllCameraMovements()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollision();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp
            (transform.position, _targetTransform.position, ref _cameraFollowVelocity, _cameraFollowSpeed);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        _lookAngle = _lookAngle + (_inputManager._cameraInputX * _cameraLookSpeed);
        _pivotAngle = _pivotAngle - (_inputManager._cameraInputY * _cameraPivotSpeed);
        _pivotAngle = Mathf.Clamp(_pivotAngle, _minimumPivotAngle, _maximumPivotAngle);

        rotation = Vector3.zero;
        rotation.y = _lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = _pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        _cameraPivot.localRotation = targetRotation;

    }

    private void HandleCameraCollision()
    {
        float targetPosition = _defaultPosition;
        RaycastHit hit;
        Vector3 direction = _cameraTransform.position - _cameraPivot.position;
        direction.Normalize();

        if(Physics.SphereCast
            (_cameraPivot.transform.position, _cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), _collisionLayers))
        {
            float distance = Vector3.Distance(_cameraPivot.position, hit.point);
            targetPosition = targetPosition - (distance - _cameraCollisionOffset);
            //Debug.Log("camera on collision range");
        }

        if(Mathf.Abs(targetPosition) < _minimumCollisionOffset) targetPosition = targetPosition - _minimumCollisionOffset;

        _cameraVectorPosition.z = Mathf.Lerp(_cameraTransform.localPosition.z, targetPosition, 0.2f);
        _cameraTransform.localPosition = _cameraVectorPosition;
    }
}
