using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFighterAttackState : AIFighterStateBase {

    private int randomLimit;
    private int hitType;

    public AIFighterAttackState(AIFighter controlled) : base (controlled){
        
    }

    public override void StartState()
    {
        randomLimit = RandomHitsLimit(5, 8);
        hitType = RandomHitsLimit (0,7);
        Debug.Log(randomLimit);
    }

    public override void UpdateState()
    {
        
        if (controlledFighter.myFighter.NumberOfHits > randomLimit)
        {
            controlledFighter.myFighter.NumberOfHits = 0;
            controlledFighter.MakeTransition(AIFighterState.Block);     
        }
        if (hitType < 5)
        {
            controlledFighter.myFighter.SimpleHit();
            controlledFighter.MakeTransition(AIFighterState.Idle); 
        } else if(hitType > 4){
            controlledFighter.myFighter.SpecialHit();
            controlledFighter.MakeTransition(AIFighterState.Idle); 
        }
        
        if (!IsCloseEnough(controlledFighter .ChaseRange ))
        {
            controlledFighter.MakeTransition(AIFighterState.Idle);
        }
    }
}
