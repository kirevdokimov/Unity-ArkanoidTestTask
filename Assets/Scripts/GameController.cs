
using UnityEngine;

public class GameController : MonoBehaviour{
	public static GameController instance = null;

	void Start(){
		if (instance == null){
			instance = this;
		} else if (instance == this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
}