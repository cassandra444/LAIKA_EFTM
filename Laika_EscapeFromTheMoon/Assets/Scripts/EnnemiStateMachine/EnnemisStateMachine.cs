using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations.Rigging;

public class EnnemisStateMachine : MonoBehaviour
{
    #region State Machine


    public EnnemisBaseState currentState;
    [Header("State Machine")]
    public TextMeshProUGUI _stateText;

    [Header("Emissive Color")]
    public Color EmissiveBlue;
    public Color EmissiveYellow;
    public Color EmissiveRed;
    public Renderer EnnemiRend;

    public Rig EnnemiRig;



    void Start()
    {

        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();

    }

    void Update()
    {
        _stateText.text = currentState.name;

        if (currentState != null)
            currentState.UpdateLogic();

        if (freezeRangeChecker.LaikaIsInFreezeRange == true && laikaStateMachine.currentState.name == "LaikaInteract") EnnemiIsFreezed = true;
        //pas sure de ça
        else EnnemiIsFreezed = false;

    }

    void LateUpdate()
    {

        if (currentState != null)
            currentState.UpdatePhysics();

    }

    protected virtual EnnemisBaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(EnnemisBaseState newState)
    {

        currentState.Exit();

        currentState = newState;
        currentState.Enter();

    }

    #endregion

    #region Work / Patroll

    [Header("Bases")]
    public Rigidbody EnnemiRB;
    public Transform EnnemiTransform;
    public Animator EnnemiAnimator;

    [Header(" Work")]
    public float WorkDuration;

    [Header(" Patroll")]
    public Transform[] EnnemiPatrollPointArr;
    public int CurrentWaypointIndex = 0;
    public float PatrollSpeed;

    #endregion

    #region Freeze

    [Header("Freeze")]
    public float FreezeDuration;
    public FreezeRangeChecker freezeRangeChecker;
    public LaikaStateMachine laikaStateMachine;
    public bool EnnemiIsFreezed;

    #endregion

    #region Detection
    [Header("Detection")]
    public LayerMask LaikaLayerMask; 
    public Transform EnnemiHeadTransform;

    //Test 17 Raycasts
    public float RaycastDistance;
    public float RayCastEndPoint;
    public float RaycastDiameter;

    //Test SphereCast
    //public float SphereCastRadius;
    //public float SpereCastEnd;
    //public Vector3 SpereCastEndPos;

    public bool LaikaInDetectionRange;
    public float DetecDuration;
    public Vector3 LaikaPoint;
    public float AttackDuration;

    public Image[] DetectionStateIndicatorImage;
    public Color Yellow;
    public Color Red;
    public Color Blue;



    public void FixedUpdate()
    {

        #region  Raycasts creation
        RaycastHit hit;

        var Ray0 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray1 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, 1f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, 1f * RaycastDiameter, RayCastEndPoint), Color.red);

        var Ray2 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, -1f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, -1f * RaycastDiameter, RayCastEndPoint), Color.red);

        var Ray3 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(1f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(1f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray4 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-1f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-1f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray5 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.7f * RaycastDiameter, 0.7f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.7f * RaycastDiameter, 0.7f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray6 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.7f * RaycastDiameter, -0.7f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.7f * RaycastDiameter, -0.7f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray7 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.7f * RaycastDiameter, -0.7f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.7f * RaycastDiameter, -0.7f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray8 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.7f * RaycastDiameter, 0.7f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.7f * RaycastDiameter, 0.7f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray9 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, 0.5f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, 0.5f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray10 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, -0.5f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0f * RaycastDiameter, -0.5f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray11 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.5f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.5f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray12 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.5f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.5f * RaycastDiameter, 0f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray13 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.34f * RaycastDiameter, -0.34f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.34f * RaycastDiameter, -0.34f, RayCastEndPoint), Color.red);

        var Ray14 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.34f * RaycastDiameter, 0.34f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(0.34f * RaycastDiameter, 0.34f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray15 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.34f * RaycastDiameter, 0.34f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.34f * RaycastDiameter, 0.34f * RaycastDiameter, RayCastEndPoint) , Color.red);

        var Ray16 = new Ray(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.34f * RaycastDiameter, -0.34f * RaycastDiameter, RayCastEndPoint));
        Debug.DrawRay(EnnemiHeadTransform.position, EnnemiHeadTransform.TransformDirection(-0.34f * RaycastDiameter, -0.34f * RaycastDiameter, RayCastEndPoint) , Color.red);

        #endregion


        // Si l'un des raycast collider avec Laika  (un gameObject du layer laika)
        //ALORS Le bool de detection de laika dans la zone renvoie true ET Le V3 LaikaPOint est égal au transform du collider detecté
        if (Physics.Raycast(Ray1, out hit, RaycastDistance, LaikaLayerMask) || Physics.Raycast(Ray2, out hit, RaycastDistance, LaikaLayerMask) ||
            Physics.Raycast(Ray3, out hit, RaycastDistance, LaikaLayerMask) || Physics.Raycast(Ray4, out hit, RaycastDistance, LaikaLayerMask) ||
            Physics.Raycast(Ray5, out hit, RaycastDistance, LaikaLayerMask) || Physics.Raycast(Ray6, out hit, RaycastDistance, LaikaLayerMask) ||
            Physics.Raycast(Ray7, out hit, RaycastDistance, LaikaLayerMask) || Physics.Raycast(Ray8, out hit, RaycastDistance, LaikaLayerMask) ||
            Physics.Raycast(Ray9, out hit, RaycastDistance, LaikaLayerMask) || Physics.Raycast(Ray10, out hit, RaycastDistance, LaikaLayerMask) ||
            Physics.Raycast(Ray11, out hit, RaycastDistance, LaikaLayerMask) || Physics.Raycast(Ray12, out hit, RaycastDistance, LaikaLayerMask) ||
            Physics.Raycast(Ray13, out hit, RaycastDistance, LaikaLayerMask) || Physics.Raycast(Ray14, out hit, RaycastDistance, LaikaLayerMask) ||
            Physics.Raycast(Ray15, out hit, RaycastDistance, LaikaLayerMask) || Physics.Raycast(Ray16, out hit, RaycastDistance, LaikaLayerMask) ||
            Physics.Raycast(Ray0, out hit, RaycastDistance, LaikaLayerMask))
        {
            
            LaikaInDetectionRange = true;
            LaikaPoint = hit.collider.transform.position;
        }
        //SINON Le bool de detection de laika dans la zone renvoie false
        else LaikaInDetectionRange = false;

    }

    #endregion

 
}
