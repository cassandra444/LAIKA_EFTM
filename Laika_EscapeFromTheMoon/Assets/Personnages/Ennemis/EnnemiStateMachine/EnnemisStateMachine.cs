using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnnemisStateMachine : MonoBehaviour
{
    #region State Machine


    EnnemisBaseState currentState;
    [Header("State Machine")]
    public TextMeshProUGUI _stateText;


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

    public Image[] DetectionStateIndicatorImage;
    public Color Yellow;
    public Color Red;
    public Color Blue;



    public void FixedUpdate()
    {

        #region Test 17 Raycast
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
            DetectionStateIndicatorImage[0].color = Yellow;
            DetectionStateIndicatorImage[1].color = Yellow;
            DetectionStateIndicatorImage[2].color = Yellow;
            DetectionStateIndicatorImage[3].color = Yellow;
            LaikaInDetectionRange = true;
        }
        else
        {
            DetectionStateIndicatorImage[0].color = Blue;
            DetectionStateIndicatorImage[1].color = Blue;
            DetectionStateIndicatorImage[2].color = Blue;
            DetectionStateIndicatorImage[3].color = Blue;
            LaikaInDetectionRange = false;
        }
        #endregion

        #region CheckSphere

        
        /*SpereCastEndPos = EnnemiHeadTransform.TransformDirection(0f , 0f , SpereCastEnd);
        Debug.DrawRay(EnnemiHeadTransform.position, SpereCastEndPos, Color.red);
        



        //Debug.DrawLine(new Vector3(EnnemiHeadTransform.position.x + SphereCastRadius / 2, EnnemiHeadTransform.position.y, EnnemiHeadTransform.position.z + SphereCastRadius / 2),
        //new Vector3(SpereCastEndPos.x + SphereCastRadius / 2, SpereCastEndPos.y, SpereCastEndPos.z + SphereCastRadius / 2), 
        //Color.red);

        /*if (Physics.CheckCapsule(EnnemiHeadTransform.position, SpereCastEndPos, SphereCastRadius, LaikaLayerMask))*/
        /*if(Physics.CheckBox(EnnemiHeadTransform.position, new Vector3(SphereCastRadius / 2, SphereCastRadius / 2, SpereCastEnd / 2), EnnemiHeadTransform.rotation, LaikaLayerMask))
        {
            DetectionStateIndicatorImage[0].color = Yellow;
            DetectionStateIndicatorImage[1].color = Yellow;
            DetectionStateIndicatorImage[2].color = Yellow;
            DetectionStateIndicatorImage[3].color = Yellow;
            LaikaInDetectionRange = true;
        }else
        {
            DetectionStateIndicatorImage[0].color = Blue;
            DetectionStateIndicatorImage[1].color = Blue;
            DetectionStateIndicatorImage[2].color = Blue;
            DetectionStateIndicatorImage[3].color = Blue;
            LaikaInDetectionRange = false;
        }*/

        #endregion

    }

    #endregion

 
}
