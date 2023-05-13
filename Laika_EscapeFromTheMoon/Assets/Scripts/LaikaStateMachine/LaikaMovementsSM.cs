using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaMovementsSM : LaikaStateMachine
{
    [HideInInspector]
    public LaikaIdle laikaIdle;
    [HideInInspector]
    public LaikaWalk laikaWalk;
    [HideInInspector]
    public LaikaSprint laikaSprint;
    [HideInInspector]
    public LaikaInteract laikaInteract;

    



    private void Awake()
    {
        laikaIdle = new LaikaIdle(this);
        laikaWalk = new LaikaWalk(this);
        laikaSprint = new LaikaSprint(this);
        laikaInteract = new LaikaInteract(this);


    }

    protected override LaikaBaseState GetInitialState()
    {
        return laikaIdle;
    }

  
}
