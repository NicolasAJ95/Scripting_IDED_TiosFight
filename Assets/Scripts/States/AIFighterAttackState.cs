using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFighterAttackState : AIFighterStateBase {

    private int randomLimit;

    public AIFighterAttackState(AIFighter controlled) : base (controlled){
        
    }

    public override void StartState()
    {
        randomLimit = RandomHitsLimit(5, 8);
        Debug.Log(randomLimit);
    }

    public override void UpdateState()
    {
        
        if (controlledFighter.myFighter.NumberOfHits > randomLimit)
        {
            controlledFighter.myFighter.NumberOfHits = 0;
            controlledFighter.MakeTransition(AIFighterState.Block);     
        }
        if (CanAttack ())
        {
            controlledFighter.myFighter.SimpleHit();
        } else if (!IsCloseEnough(controlledFighter .ChaseRange ))
        {
            controlledFighter.MakeTransition(AIFighterState.Idle);
        }
    }
}
