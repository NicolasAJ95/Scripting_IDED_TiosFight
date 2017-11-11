using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFighterMoveState : AIFighterStateBase {

    public AIFighterMoveState (AIFighter controlled) : base(controlled)
    {

    }

    public override void UpdateState() {

        

        if (!IsCloseEnough(controlledFighter .MeleeRange ))
        {
            MoveToTarget();
        }
        else controlledFighter.MakeTransition(AIFighterState.Idle);
        
    }

    private void MoveToTarget()
    {
        if (controlledFighter.transform.localScale.x > 0)
        {
            controlledFighter.myFighter.MovePlayer(controlledFighter.MoveSpeed);
        }
        else if (controlledFighter.transform.localScale.x < 0)
        {
            controlledFighter.myFighter.MovePlayer(-controlledFighter.MoveSpeed);
        }
    }
}
