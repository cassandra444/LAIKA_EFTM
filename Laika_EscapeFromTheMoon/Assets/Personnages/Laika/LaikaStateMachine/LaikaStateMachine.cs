using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LaikaStateMachine : MonoBehaviour
{
    #region State Machine
    LaikaBaseState currentState;
    public InputActionLEFTM _laikaControls;
    public CameraManager _cameraManager;

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

        // Appelle la fonction définisant les variable d'input pour qu'ils soient verifiés à toutes les frames
        HandleMovementsInput();
       
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();

        //Appelle la fonction qui gère la caméra dans le camera Manager 
        _cameraManager.HandleAllCameraMovements();
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

    // Affiche la current State
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

    private void Awake()
    {
        _cameraObject = Camera.main.transform;
    }


    private void OnEnable()
    {
        if (_laikaControls == null)
        {
            //Récuperer l'input action InputActionLEFTM();
            _laikaControls = new InputActionLEFTM();

            // Récuperer le Vecteur 2 du joystick gauche/ZQSD pour les déplacements
            _laikaControls.LaikaMovements.Mouvements.performed += i => _mouvementInput = i.ReadValue<Vector2>();

            // Récuperer le Vecteur 2 du joystick droit/souris pour les mouvements de la caméra
            _laikaControls.LaikaMovements.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();

            // Vérifie si l'input de sprint est ou n'est pas enclenché
            _laikaControls.LaikaActions.SprintButton.performed += i => _sprintInput = true;
            _laikaControls.LaikaActions.SprintButton.canceled += i => _sprintInput = false;

            // Vérifie si l'input d'interaction est ou n'est pas enclenché
            _laikaControls.LaikaActions.AttackButton.performed += i => _interactInput = true;
            _laikaControls.LaikaActions.AttackButton.canceled += i => _interactInput = false;

        }
         // Re vérifier
        _laikaControls.Enable();
    }

    // en cas de potentiel futur besoin de désactivation des controles ( mort, menu ... )
    private void OnDisable()
    {    
        _laikaControls.Disable();
    }


    // Définit les paramètre de mouvement pour ne pas poluer l'update
    private void HandleMovementsInput()
    {
        _verticalInput = _mouvementInput.y;
        _horizontalInput = _mouvementInput.x;

        _cameraInputX = _cameraInput.x;
        _cameraInputY = _cameraInput.y;

        _moveAmount = Mathf.Clamp01(Mathf.Abs(_horizontalInput) + Mathf.Abs(_verticalInput));
    }

    


    #endregion

    #region Gestion Mouvements

    [Header("Parametres de déplacements")]
    public float _walkingSpeed = 1.5f;
    public float _sprintingSpeed = 7f;
    public float _rotationSpeed = 15f;

    public void HandleMovements(float p_speed)
    {
        //faire avancer le personnaage dans la direction que la camera regarde x la direction y du joystick/ZQSD
        _moveDirection = _cameraObject.forward * _verticalInput;
        _moveDirection = _moveDirection + _cameraObject.right * _horizontalInput;
        _moveDirection.Normalize();
        //Ne pas bouger sur l'axe y
        _moveDirection.y = 0f;
       
        // multiplier la valeur par la vitesse souhaité 
        _moveDirection = _moveDirection * p_speed;

        Vector3 _movementVelocity = _moveDirection;

        //faire bouger Laika selon la direction et la vitesse
        _laikaRigidbody.velocity = _movementVelocity;
        
    }

    public void HandleRotation()
    {
        Vector3 _targetDirection = Vector3.zero;

        // faire tourner Laika selon la direction que la camera regarde x la direction y du joystick/ZQSD
        _targetDirection = _cameraObject.forward * _verticalInput;
        _targetDirection = _targetDirection + _cameraObject.right * _horizontalInput;
        _targetDirection.Normalize();
        //Ne pas tourner sur l'axe y
        _targetDirection.y = 0f;

        // si laika ne bouge pas, alors regarder en face 
        if (_targetDirection == Vector3.zero) _targetDirection = transform.forward;

        //faire tourner Laika selon la direction et la vitesse
        Quaternion _targetRotation = Quaternion.LookRotation(_targetDirection);
        Quaternion _laikaRotation = Quaternion.Slerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

        transform.rotation = _laikaRotation;
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

        //Normalisation de la valeur su float horizontal du blend tree selon 3 paliers
        #region Snapped Horizontal
        if (p_horizontalMovement > 0f && p_horizontalMovement < 0.55f) snappedHorizontal = 0.5f;
        else if (p_horizontalMovement > 0.55f) snappedHorizontal = 1f;
        else if (p_horizontalMovement < 0f && p_horizontalMovement > -0.55f) snappedHorizontal = -0.5f;
        else if (p_horizontalMovement < -0.55f) snappedHorizontal = -1f;
        else snappedHorizontal = 0f;
        #endregion

        //Normalisation de la valeur su float horizontal du blend tree selon 3 paliers
        #region Snapped Vertical
        if (p_verticalMovement > 0f && p_verticalMovement < 0.55f) snappedVertical = 0.5f;
        else if (p_verticalMovement > 0.55f) snappedVertical = 1f;
        else if (p_verticalMovement < 0f && p_verticalMovement > -0.55f) snappedVertical = -0.5f;
        else if (p_verticalMovement < -0.55f) snappedVertical = -1f;
        else snappedVertical = 0f;
        #endregion

        // Appliquer les valeurs
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

    #region Interaction

    [Header("Paremetres d'Interaction")]
    public float InteractionDuration;
    public Transform InteractionTarget;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractionTarget"))
        {
            InteractionTarget = other.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        InteractionTarget = null;     
    }


   
    
    #endregion


}
