using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGrid : MonoBehaviour{

	[SerializeField] private GameObject prefab;

	public int w, h;
	
	// Use this for initialization
	void Start () {
		for (var i = -w; i < w; i++){
			for (var j = -h; j < h; j++){
				Instantiate(prefab, transform.position + Vector3.right*i*1.2f + Vector3.down*j, Quaternion.identity, transform);
			}
		}
	}
}
