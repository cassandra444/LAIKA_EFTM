using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaikaStateMachine : MonoBehaviour
{
    #region State Machine
    LaikaBaseState currentState;
    public InputActionLEFTM _laikaControls;
    

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();

        
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();

        HandleMovementsInput();

    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    protected virtual LaikaBaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(LaikaBaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    private void OnGUI()
    {

        GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndArea();

    }
    #endregion

    #region Gestion Input

    [HideInInspector]
    public Vector2 _mouvementInput;
    [HideInInspector]
    public Vector2 _cameraInput;

    [Header("Paremetres d'Input Laika")]
    public float _moveAmount;
    public float _verticalInput;
    public float _horizontalInput;
    public bool _sprintInput;
    public bool _interactInput;

    [Header("Paremetres d'Input Camera")]
    public float _cameraInputX;
    public float _cameraInputY;

    [Header("References de déplacements")]
    public Vector3 _moveDirection;
    public Transform _cameraObject;
    public Rigidbody _laikaRigidbody;
    public Transform _laikaTransform;
    //public Animator _laikaAnimation;

    [Header("Parametres de déplacements")]
    public float _walkingSpeed = 1.5f;
    public float _sprintingSpeed = 7f;
    public float _runningSpeed = 5f;
    public float _rotationSpeed = 15f;

    private void Awake()
    {
        _cameraObject = Camera.main.transform;
        //horizontal = Animator.StringToHash("Horizontal");
        //vertical = Animator.StringToHash("Vertical");

    }


    private void OnEnable()
    {
        if (_laikaControls == null)
        {
            _laikaControls = new InputActionLEFTM();
            _laikaControls.LaikaMovements.Mouvements.performed += i => _mouvementInput = i.ReadValue<Vector2>();
            _laikaControls.LaikaMovements.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();

            _laikaControls.LaikaActions.SprintButton.performed += i => _sprintInput = true;
            _laikaControls.LaikaActions.SprintButton.canceled += i => _sprintInput = false;

            _laikaControls.LaikaActions.AttackButton.performed += i => _interactInput = true;
            _laikaControls.LaikaActions.AttackButton.canceled += i => _interactInput = false;

        }

        _laikaControls.Enable();
    }

    private void OnDisable()
    {
        _laikaControls.Disable();
    }

    private void HandleMovementsInput()
    {
        _verticalInput = _mouvementInput.y;
        _horizontalInput = _mouvementInput.x;

        _cameraInputX = _cameraInput.x;
        _cameraInputY = _cameraInput.y;

        _moveAmount = Mathf.Clamp01(Mathf.Abs(_horizontalInput) + Mathf.Abs(_verticalInput));
    }
    #endregion

    #region Gestion Animation

    public Animator _laikaAnimator;
    int horizontal;
    int vertical;


    public void UpdateWalkAnimatorValue(float p_horizontalMovement, float p_verticalMovement, bool p_isSprinting)
    {
        float snappedHorizontal;
        float snappedVertical;

        #region Snapped Horizontal
        if (p_horizontalMovement > 0f && p_horizontalMovement < 0.55f) snappedHorizontal = 0.5f;
        else if (p_horizontalMovement > 0.55f) snappedHorizontal = 1f;
        else if (p_horizontalMovement < 0f && p_horizontalMovement > -0.55f) snappedHorizontal = -0.5f;
        else if (p_horizontalMovement < -0.55f) snappedHorizontal = -1f;
        else snappedHorizontal = 0f;
        #endregion
        #region Snapped Vertical
        if (p_verticalMovement > 0f && p_verticalMovement < 0.55f) snappedVertical = 0.5f;
        else if (p_verticalMovement > 0.55f) snappedVertical = 1f;
        else if (p_verticalMovement < 0f && p_verticalMovement > -0.55f) snappedVertical = -0.5f;
        else if (p_verticalMovement < -0.55f) snappedVertical = -1f;
        else snappedVertical = 0f;
        #endregion

        _laikaAnimator.SetFloat(Animator.StringToHash("Horizontal"), snappedHorizontal, 0.1f, Time.deltaTime);
        _laikaAnimator.SetFloat(Animator.StringToHash("Vertical"), snappedVertical, 0.1f, Time.deltaTime);
    }

    public void UpdateSprintAnimatorValue(float p_horizontalMovement, float p_verticalMovement, bool p_isSprinting)
    {
        float snappedHorizontal;
        float snappedVertical;

        snappedHorizontal = p_horizontalMovement;
        snappedVertical = 2f;
        
        _laikaAnimator.SetFloat(Animator.StringToHash("Horizontal"), snappedHorizontal, 0.1f, Time.deltaTime);
        _laikaAnimator.SetFloat(Animator.StringToHash("Vertical"), snappedVertical, 0.1f, Time.deltaTime);
    }

    public void PlayInteractAnim()
    {
        _laikaAnimator.SetBool("IsInteracting", true);
    }

    public void StopInteractAnim()
    {
        _laikaAnimator.SetBool("IsInteracting", false);
    }

    #endregion


}
