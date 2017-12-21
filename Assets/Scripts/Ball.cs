using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{

	public Vector3 startVelocity;
	
	Rigidbody2D rig;
	Vector2 oldVel;
 
	void Start () {
		rig = GetComponent<Rigidbody2D>();
		rig.velocity = startVelocity;
	}
     
	void FixedUpdate() {
		oldVel = rig.velocity;
	}

	private void OnCollisionEnter2D (Collision2D c) {
		var cp = c.contacts[0];
		rig.velocity = Vector2.Reflect(oldVel,cp.normal);
		
		if (c.gameObject.CompareTag("Block")){
			c.gameObject.GetComponent<Block>().Shot();
		}
	}
	
	
}
