using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fliper : MonoBehaviour
{
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(this.transform.position, Vector2.right);
        if (hit.transform != null)
        {
            Debug.Log(hit.transform.name);
        }
	}
}
