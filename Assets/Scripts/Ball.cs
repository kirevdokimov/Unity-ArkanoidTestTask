using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour{

	public float speed;
	
	Rigidbody2D rig;
	Vector2 oldVel;
 
	void Start () {
		rig = GetComponent<Rigidbody2D>();
		Spawn();
	}
     
	void FixedUpdate() {
		oldVel = rig.velocity;
	}

	void Update(){
		if (!readyToPush) return;
		AlignWithPlayer();
	}


	public void AlignWithPlayer(){
		transform.position = playerTransform.position + Vector3.up * 0.8f;
	}

	[SerializeField]
	private Transform playerTransform;

	public bool readyToPush{ get; private set; }

	private void Spawn(){
		AlignWithPlayer();
		rig.velocity = Vector2.zero;
		readyToPush = true;
	}

	public void Push(){
		if(!readyToPush) return;
		transform.parent = null;
		rig.velocity = GetRandomPushVector() * speed;
		readyToPush = false;
	}

	private Vector2 GetRandomPushVector(){
		return Quaternion.AngleAxis(Random.Range(30f,150f), Vector3.forward) * Vector2.right;
	}

	private void OnCollisionEnter2D (Collision2D c) {
		var cp = c.contacts[0];
		var newVelo = Vector2.Reflect(oldVel,cp.normal).normalized;

		if (c.gameObject.CompareTag("Player")){
			var plpos = c.gameObject.GetComponent<Transform>().position;
			var deltaX = transform.position.x - plpos.x;
			newVelo += Vector2.right*0.5f*deltaX;
		}

		rig.velocity = newVelo.normalized * speed;

		if (c.gameObject.CompareTag("Block")){
			c.gameObject.GetComponent<Block>().Shot();
		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Deadzone")){
			//UiController.instance.SetState(UiController.GameStatus.LOSE);
			if (GameController.instance.LostBall()){
				GameController.instance.SetState(GameController.GameStatus.LOSE);
			} else{
				Spawn();
			}
		}
	}
}
