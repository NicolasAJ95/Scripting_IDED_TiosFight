using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXKiller : MonoBehaviour {

	[SerializeField]
	private float deathTime;
	[SerializeField]
	private float timer;

	void OnEnable()
	{
		timer = 0.0f;
	}

	
	void Update()
	{
		timer += Time.deltaTime;
		if(timer >= deathTime )
		BloodPool .Instance.ReleaseBlood (gameObject);
	}
}
