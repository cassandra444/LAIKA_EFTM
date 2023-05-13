using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Blue print, utilisée comme base pour créer toutes les autres states
public class LaikaBaseState
{
    #region Outil pour afficher la current state 
    public string name;
    protected LaikaStateMachine laikaStateMachine;

    public LaikaBaseState(string name, LaikaStateMachine laikaStateMachine)
    {
        this.name = name;
        this.laikaStateMachine = laikaStateMachine;
    }
    #endregion

    public virtual void Enter() { }

    public virtual void UpdateLogic() { }

    public virtual void UpdatePhysics() { }

    public virtual void Exit() { }
}


