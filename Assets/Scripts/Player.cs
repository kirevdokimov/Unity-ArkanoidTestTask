using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour{

	
	[SerializeField, Range(3,15)] private float startSize;

	public float speed;

	[SerializeField] private float moveRange;
	
	private float size;
	public float Size{
		get{ return size; }
		set{
			size = Mathf.Clamp(value, 3, moveRange*2);
			transform.localScale = new Vector3(size,1,1);
		}
	}

	private void Start (){
		Size = startSize;
	}

	public Ball ball;

	private void Update(){

		if (ball.readyToPush && Input.GetKeyDown(KeyCode.Space)){
			PushBall();
		}

		Movement();
		Clamp();
	}

	private void Movement(){
		float x = Input.GetAxis("Horizontal");
		transform.Translate(Vector3.right * x * speed * Time.deltaTime);
	}

	private void Clamp(){
		var pos = transform.position;
		pos.x =  Mathf.Clamp(transform.position.x, -moveRange+(Size/2), moveRange-(Size/2));
		transform.position = pos;
	}

	private void PushBall(){
		ball.Push();
	}

	private void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(Vector3.left*moveRange, .25f);
		Gizmos.DrawWireSphere(Vector3.right*moveRange, .25f);
		Gizmos.DrawLine(Vector3.left*moveRange,Vector3.right*moveRange);
	}

	private void OnValidate(){
		moveRange = moveRange < 0 ? 0 : moveRange;
		Size = startSize;
	}
}
