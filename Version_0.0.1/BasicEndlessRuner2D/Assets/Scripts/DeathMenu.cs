using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class DeathMenu : MonoBehaviour
{

    public string mainMenuLevel;
	private string mapMenuScene = "SelectMap";

    public void RestartGame()
    {

        FindObjectOfType<GameManager>().Reset();

    }

	public void QuitToMapMenu(){

		Application.LoadLevel (mapMenuScene);
	
	}

    public void QuitToMainMenu()
    {

		Application.LoadLevel(mainMenuLevel);
    }
}
