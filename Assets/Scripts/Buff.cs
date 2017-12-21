using UnityEngine;
[System.Serializable]
public class Buff{

	public float expirationTime;
	public float value;

	public enum Type{
		SIZE_INCREASE,SIZE_DECREASE
	}

	[SerializeField] private Type type;

	public Buff(float expTime,Type t){
		expirationTime = Mathf.Clamp(expTime,0,float.MaxValue);
		type = t;
	}

	public bool Dissolve(float time){
		expirationTime -= time;
		return expirationTime <= 0;
	}

	public void Do(Player p){
		switch(type){
			case Type.SIZE_INCREASE: p.Size += value; break;
			case Type.SIZE_DECREASE: p.Size -= value; break;
		}
	}
	public void Undo(Player p){
		value = -value;
		Do(p);
	}

}