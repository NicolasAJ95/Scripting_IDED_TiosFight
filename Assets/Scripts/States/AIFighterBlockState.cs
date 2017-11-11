using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFighterBlockState : AIFighterStateBase {

    private float healthLimit;
    
    private float timer;

    public AIFighterBlockState(AIFighter controlled) : base(controlled)
    {

    }

    public override void StartState()
    {
        timer = 0.0f;
        healthLimit = RandomHitsLimit(0, 40);
        controlledFighter.myFighter.Block(true);
    }

    public override void UpdateState()
    {
        timer += 0.0097f;
        
        if (controlledFighter.myFighter.MyShield.Health < healthLimit || timer > 8.0f)
        {
            ToIdle();
        }
        
    }

    private void ToIdle() {
        controlledFighter.myFighter.Block(false);
        controlledFighter.myFighter.NumberOfHits = 0;
        controlledFighter.MakeTransition(AIFighterState.Idle);
    }
}
