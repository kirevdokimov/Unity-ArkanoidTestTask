using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{


	[SerializeField] private GameObject goodBuff;
	[SerializeField] private GameObject badBuff;

	public void Shot(){
		GameController.instance.Score++;
		
		if (transform.parent.childCount <= 1){
			GameController.instance.SetState(GameController.GameStatus.WIN);
		}
		
		// Шанс 2/6, что выпадет бонус
		var n = Random.Range(0, 7);
		switch (n){
			case 0: Instantiate(goodBuff, transform.position, Quaternion.identity);
				break;
			case 1: Instantiate(badBuff, transform.position, Quaternion.identity);
				break;
		}
		Destroy(gameObject);
	}
}
