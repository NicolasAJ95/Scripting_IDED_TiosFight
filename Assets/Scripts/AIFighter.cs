using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class AIFighter : MonoBehaviour {
	//Fighter Properties
	[SerializeField]
	private float moveSpeedAmount;
	[SerializeField]
	private int simpleHitAmount;
	[SerializeField]
	private int specialHitAmount;
	[SerializeField]
	private int receiveDamage;

    
    public Fighter myFighter;
	[SerializeField]
	private Vector3 distanceToPlayer;

	[SerializeField]
	private float meleeRange;
    [SerializeField]
    private float chaseRange;
    [SerializeField]
    private float idleTime;


    public float MeleeRange
    {
        get
        {
            return meleeRange;
        }
    }
    public float ChaseRange
    {
        get
        {
            return chaseRange;
        }
    }
    public float IdleTime
    {
        get
        {
            return idleTime;
        }
    }
    public float MoveSpeed
    {
        get
        {
            return moveSpeedAmount;
        }
    }

    

    public Transform chaseTarget;

    private AIFighterStateBase currentState;
    private Dictionary<AIFighterState, AIFighterStateBase> states;

	private void Start()
	{
		myFighter = GetComponent<Fighter>();

        GameObject chaseParent = GameObject.Find("CharacterPlayer1");
        var index = PlayerPrefs.GetInt("CharacterPlayer1");
        chaseTarget = chaseParent.transform.GetChild(index);

        states = new Dictionary<AIFighterState, AIFighterStateBase>();
        states.Add(AIFighterState.Idle, new AIFighterIdleState(this));
        states.Add(AIFighterState.Attack, new AIFighterAttackState(this));
        states.Add(AIFighterState.Move, new AIFighterMoveState(this));
        states.Add(AIFighterState.Block, new AIFighterBlockState(this));
        currentState = states[AIFighterState.Idle];
        currentState.StartState();
    }

    public void MakeTransition (AIFighterState state)
    {
        Debug.Log(state);
        currentState = states[state];
        currentState.StartState();
    }

	private void Update()
    {

        currentState.UpdateState();

	}

	private void FixedUpdate()
    {

	//	float h = Input .GetAxis("Horizontal");
    
	//	myFighter .MovePlayer(h * moveSpeedAmount);

	}


}
