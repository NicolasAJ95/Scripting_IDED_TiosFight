using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipDetectionCollider : MonoBehaviour {

private Fighter myFighter;

private void Start(){
	myFighter = GetComponentInParent <Fighter>();
}

void OnTriggerEnter2D(Collider2D col)
 {
    if (col.tag == "Fighter")
	myFighter.Flip();
}

    
}
