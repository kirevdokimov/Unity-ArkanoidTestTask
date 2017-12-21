
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

	public static GameController instance = null;

	private void Awake(){
		instance = FindObjectOfType<GameController>() ?? new GameObject().AddComponent<GameController>();
	}

	public int health = 5;
	public int score = 0;

	public Text heal;
	public Text scor;

	public bool LostBall(){
		health--;
		heal.text = new string('♥', health);
		return health == 0;
	}

	public void IncScore(){
		score++;
		scor.text = "Score " + score;

	}

	public RectTransform los;
	public RectTransform win;
	public RectTransform gam;

	public enum GameStatus{
		WIN, LOSE, GAME
	}

	private RectTransform currentRect;
	private RectTransform previousRect;
	
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