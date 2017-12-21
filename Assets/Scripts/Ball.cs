using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = Vector2.down*2+Vector2.left*1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
