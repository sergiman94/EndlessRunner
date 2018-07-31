using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string playGameLevel1;
	private string settingsScene = "Settings";
	private string mainMenuScene = "MainMenu";
	private string charactersMenu = "CharactersMenu";

	public void PlayGame(){
			
		Application.LoadLevel (playGameLevel1);
	}

	public void PlaySettings(){
		
		Application.LoadLevel(settingsScene);
	}

	public void PlayMainMenu(){
	
		Application.LoadLevel (mainMenuScene);
	}

	public void PlayCharactersMenu(){
	
		Application.LoadLevel (charactersMenu);
	}

	public void QuitGame(){
	
		Application.Quit ();
	
	}
}
