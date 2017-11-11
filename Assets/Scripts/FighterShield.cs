using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterShield : MonoBehaviour {

    [SerializeField]
    private float health;

    private bool isBlocking;

    public float Health
    {
        get
        {
            return health;
        }
    }

    public bool IsBlocking
    {
        get
        {
            return isBlocking;
        }
    }

    private void OnEnable()
    {
        isBlocking = true;
        health = 100;
    }

    private void ReceiveDamage(float damage)
    {
        health -= damage * 2;
        if(health < 1)
        {
            gameObject.SetActive(false);
        }
    }

	private void OnDisable()
    {
        isBlocking = false;
    }
}
