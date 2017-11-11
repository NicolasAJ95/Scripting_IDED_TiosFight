using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIFighterState
{
    Move, Idle, Attack, Block,
}

public abstract class AIFighterStateBase : MonoBehaviour {

    protected AIFighter controlledFighter;

    public AIFighterStateBase(AIFighter controlled)
    {
        this.controlledFighter = controlled;
    }

    public virtual void StartState()
    {

    }

    public abstract void UpdateState();

    protected bool IsCloseEnough(float range)
    {
        return (controlledFighter.chaseTarget.position - controlledFighter.transform.position).magnitude < range;
    }

    protected bool CanAttack()
    {
        return (controlledFighter.myFighter.CanAttack);
    }

    protected int RandomHitsLimit(int min, int max)
    {
        int randomNumber = Random.Range(min, max);
        return randomNumber;
    }
}
