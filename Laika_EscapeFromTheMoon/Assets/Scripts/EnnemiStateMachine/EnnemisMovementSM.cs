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
    [HideInInspector]
    public EnemiDetect enemiDetect;
    [HideInInspector]
    public EnemiAttack enemiAttack;


    private void Awake()
    {
        enemiWork = new EnemiWork(this);
        enemiPatroll = new EnemiPatroll(this);
        enemiFreeze = new EnemiFreeze(this);
        enemiDetect = new EnemiDetect(this);
        enemiAttack = new EnemiAttack(this);


    }

    protected override EnnemisBaseState GetInitialState()
    {
        return enemiWork;
    }
}
