using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{


	public GameObject goodBuff;
	public GameObject badBuff;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shot(){
		GameController.instance.IncScore();
		if (transform.parent.childCount <= 1){
			GameController.instance.SetState(GameController.GameStatus.WIN);
		}
		var n = Random.Range(0, 7);
		switch (n){
			case 0: Instantiate(goodBuff, transform.position, Quaternion.identity);
				break;
			case 1: Instantiate(badBuff, transform.position, Quaternion.identity);
				break;
		}
		Destroy(this.gameObject);
	}
}
