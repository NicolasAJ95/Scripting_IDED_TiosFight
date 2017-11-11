using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fighter))]
public class PlayerFighter : MonoBehaviour {
	//Fighter Properties
	[SerializeField]
	private float moveSpeedAmount;
	[SerializeField]
	private int simpleHitAmount;
	[SerializeField]
	private int specialHitAmount;
	[SerializeField]
	private int receiveDamage;
	private Fighter myFighter;

	private void Start()
	{
		myFighter = GetComponent<Fighter>();
	}

	private void Update()
    {

		if(Input .GetKeyDown(KeyCode.H))
        {
			myFighter.SimpleHit();
		}
		if(Input .GetKeyDown(KeyCode.J))
        {
			myFighter.SpecialHit();
		}
        if (Input.GetKeyDown(KeyCode.K))
        {
            myFighter.Block(true);
        } else if (Input.GetKeyUp(KeyCode.K))
            myFighter.Block(false);

        if (Input.GetKeyDown(KeyCode.F))
        {
            myFighter.Flip();
        }
    }

	private void FixedUpdate()
    {
		float h = Input .GetAxis("Horizontal");

		myFighter .MovePlayer(h * moveSpeedAmount);
	}
}
