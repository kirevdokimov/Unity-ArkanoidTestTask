
using UnityEngine;
public class BuffGameObject : MonoBehaviour{

	[SerializeField] private Buff buff;

	private void Update(){
		transform.Translate(Vector3.down * Time.deltaTime * 2f);
	}

	public void ExtractTo(out Buff b){
		b = buff;
		Destroy(gameObject);
	}
}