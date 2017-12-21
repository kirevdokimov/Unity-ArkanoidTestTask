using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGrid : MonoBehaviour{

	public GameObject prefab;

	public int w, h;
	
	// Use this for initialization
	void Start () {
		for (int i = -w; i < w; i++){
			for (int j = -h; j < h; j++){
				Instantiate(prefab, transform.position + Vector3.right*i*1.2f + Vector3.down*j, Quaternion.identity, this.transform);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
