using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{

	public float speed = 2;
	
	Rigidbody2D rig;
	Vector2 oldVel;
 
	void Start () {
		rig = GetComponent<Rigidbody2D>();
		Spawn();
	}
     
	void FixedUpdate() {
		oldVel = rig.velocity;
	}
	
	
	[SerializeField]
	private Transform playerTransform;

	public bool readyToPush{ get; private set; }

	private void Spawn(){
		transform.position = playerTransform.position + Vector3.up * 0.8f;
		transform.parent = playerTransform;
		rig.velocity = Vector2.zero;
		readyToPush = true;
	}

	public void Push(){
		transform.parent = null;
		rig.velocity = GetRandomPushVector() * speed;
	}

	private Vector2 GetRandomPushVector(){
		return Quaternion.AngleAxis(Random.Range(30f,150f), Vector3.forward) * Vector2.right;
	}

	private void OnCollisionEnter2D (Collision2D c) {
		var cp = c.contacts[0];
		rig.velocity = Vector2.Reflect(oldVel,cp.normal);
		
		if (c.gameObject.CompareTag("Block")){
			c.gameObject.GetComponent<Block>().Shot();
		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Deadzone")){
			Spawn();
		}
	}
}
