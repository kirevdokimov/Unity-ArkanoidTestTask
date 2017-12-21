
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

	public static GameController instance = null;

	[SerializeField] private Text scor;
	private int score = 0;
	public int Score{
		get{ return score; }
		set{
			score = value;
			scor.text = "Score " + score;
		}
	}

	[SerializeField] private Text heal;
	public int health = 5;
	public int Health{
		get{ return health; }
		set{
			health = value;
			heal.text = new string('♥', health);
		}
	}
	
	

	[SerializeField] private RectTransform los;
	[SerializeField] private RectTransform win;
	[SerializeField] private RectTransform gam;
	private RectTransform currentRect;
	private RectTransform previousRect;
	
	private void Awake(){
		instance = FindObjectOfType<GameController>() ?? new GameObject().AddComponent<GameController>();
	}
	
	public enum GameStatus{
		WIN, LOSE, GAME
	}
	
	public void SetState(GameStatus stat){
		previousRect = currentRect;
		switch (stat){
			case GameStatus.WIN: currentRect = win; break;
			case GameStatus.LOSE: currentRect = los; break;
			case GameStatus.GAME: currentRect = gam; break;
		}
		if(previousRect)
			previousRect.gameObject.SetActive(false);
		currentRect.gameObject.SetActive(true);
	}

	public void Retry(){
		SceneManager.LoadScene("main");
	}
	
	
}