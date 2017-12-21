using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour{
		
	[SerializeField, Range(1,15)] private float startSize;

	public float speed;

	[SerializeField] private float moveRange;
	
	private float size;
	public float Size{
		get{ return size; }
		set{
			size = Mathf.Clamp(value, 1, moveRange*2);
			transform.localScale = new Vector3(size,transform.localScale.y,transform.localScale.z);
		}
	}

	private void Start (){
		Size = startSize;
	}

	public Ball ball;
	private Buff buff;
	private void Update(){

		if (Input.GetKeyDown(KeyCode.Space)){
			PushBall();
		}

		Movement();
		Clamp();
		
		if (buff != null){
			if (buff.Dissolve(Time.deltaTime)){
				DismissBuff();
			}
		}
	}

	public void ApplyBuff(Buff b){
		buff = b;
		buff.Do(this);
	}

	public void DismissBuff(){
		buff.Undo(this);
		buff = null;
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

	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("BuffObject")){
			Buff b;
			other.gameObject.GetComponent<BuffGameObject>().ExtractTo(out b);
			ApplyBuff(b);
		}
	}
}
