using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFighterBlockState : AIFighterStateBase {

    private float healthLimit;

    public AIFighterBlockState(AIFighter controlled) : base(controlled)
    {

    }

    public override void StartState()
    {
        healthLimit = RandomHitsLimit(0, 60);
        controlledFighter.myFighter.Block(true);
    }

    public override void UpdateState()
    {
        if (controlledFighter.myFighter.MyShield.Health < healthLimit)
        {
            ToIdle();
        }
        
    }

    private void ToIdle() {

        controlledFighter.myFighter.NumberOfHits = 0;
        controlledFighter.MakeTransition(AIFighterState.Idle);
    }
}
