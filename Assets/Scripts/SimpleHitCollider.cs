using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHitCollider : MonoBehaviour {

	private Collider2D myCollider;
	[SerializeField ]
	private float damage;

	public Collider2D MyCollider{
		get
        {
			return myCollider;
		}
		set
        {
			myCollider = value;
		}
	}

	void Start () {
		myCollider = GetComponent<Collider2D >();
	}
	public void InitializeDamage(float dmg){
		damage=dmg;
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag != this.gameObject .tag)
		{
			col.gameObject.SendMessageUpwards("ReceiveDamage", damage, 0);
		}
	}
}
