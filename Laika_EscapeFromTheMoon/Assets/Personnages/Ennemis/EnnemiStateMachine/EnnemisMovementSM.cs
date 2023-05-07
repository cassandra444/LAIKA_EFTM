using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisMovementSM : EnnemisStateMachine
{
    [HideInInspector]
    public EnemiWork enemiWork;
    [HideInInspector]
    public EnemiPatroll enemiPatroll;
    [HideInInspector]
    public EnemiFreeze enemiFreeze;
    

    private void Awake()
    {
        enemiWork = new EnemiWork(this);
        enemiPatroll = new EnemiPatroll(this);
        enemiFreeze = new EnemiFreeze(this);
        
    }

    protected override EnnemisBaseState GetInitialState()
    {
        return enemiWork;
    }
}
