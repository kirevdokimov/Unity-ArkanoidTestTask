using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shot(){
		GameController.instance.IncScore();
		if (transform.parent.childCount == 1){
			GameController.instance.SetState(GameController.GameStatus.WIN);
		}
		Destroy(this.gameObject);
	}
}
