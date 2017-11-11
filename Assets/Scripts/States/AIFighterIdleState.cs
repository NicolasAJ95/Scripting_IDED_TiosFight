using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFighterIdleState : AIFighterStateBase {

    private int randomLimit;

    private int decisionTime;
    private float decisionTimer;
    private bool canDecide;

    public AIFighterIdleState(AIFighter controlled) : base(controlled) {
    }

    public override void StartState()
    {
        decisionTime = RandomHitsLimit (0,2);
        randomLimit = RandomHitsLimit(5, 8);
        canDecide = false;
        decisionTimer = 0.0f;
    }

    public override void UpdateState()
    {
        decisionTimer += 0.0097f;
        Debug.Log(decisionTimer);
        if(decisionTimer > decisionTime ){
            canDecide = true;
        }
        if(canDecide ){
        if (controlledFighter.myFighter.NumberOfHits > randomLimit)
        {
            controlledFighter.myFighter.NumberOfHits = 0;
            controlledFighter.MakeTransition(AIFighterState.Block);
        }
        Listen();
        }
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
