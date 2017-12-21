
using UnityEngine;

public class UiController: MonoBehaviour {
	public static UiController instance = null; 

	void Start () {
		if (instance == null) { 
			instance = this;
		} else if(instance == this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		InitializeManager();
		SetState(GameStatus.GAME);
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
		SetState(GameStatus.GAME);
	}

	private void InitializeManager(){
//		music = System.Convert.ToBoolean (PlayerPrefs.GetString ("music", "true"));
//		sounds = System.Convert.ToBoolean (PlayerPrefs.GetString ("sounds", "true"));
	}

	// Метод для сохранения текущих настроек
	public static void saveSettings(){
//		PlayerPrefs.SetString ("music", music.ToString ()); // Применяем параметр музыки
//		PlayerPrefs.SetString ("sounds", sounds.ToString ()); // Применяем параметр звуков
//		PlayerPrefs.Save(); // Сохраняем настройки
	}
}