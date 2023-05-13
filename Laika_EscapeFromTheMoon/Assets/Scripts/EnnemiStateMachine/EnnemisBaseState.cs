using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisBaseState 
{
    #region Outil pour afficher la current state 
    public string name;
    protected EnnemisStateMachine ennemisStateMachine;

    public EnnemisBaseState(string name, EnnemisStateMachine ennemisStateMachine)
    {
        this.name = name;
        this.ennemisStateMachine = ennemisStateMachine;
    }
    #endregion

    public virtual void Enter() { }

    public virtual void UpdateLogic() { }

    public virtual void UpdatePhysics() { }

    public virtual void Exit() { }
}
