using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFighterIdleState : AIFighterStateBase {

    private int randomLimit;

    public AIFighterIdleState(AIFighter controlled) : base(controlled) {
    }

    public override void StartState()
    {
        randomLimit = RandomHitsLimit(5, 8);
    }

    public override void UpdateState()
    {
        if (controlledFighter.myFighter.NumberOfHits > randomLimit)
        {
            controlledFighter.myFighter.NumberOfHits = 0;
            controlledFighter.MakeTransition(AIFighterState.Block);
        }
        Listen();
    }

    public void Listen()
    {
        Debug.Log("decision");
        if (!IsCloseEnough(controlledFighter .MeleeRange ))
        {
            controlledFighter.MakeTransition(AIFighterState.Move);
        } else if (IsCloseEnough(controlledFighter .MeleeRange ))
        {
            controlledFighter.MakeTransition(AIFighterState.Attack);
        }
    }  
}
