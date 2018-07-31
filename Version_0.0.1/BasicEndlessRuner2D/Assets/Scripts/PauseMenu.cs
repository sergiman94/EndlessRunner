using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    public string mainMenuLevel;
    public GameObject pauseMenu;
	private string mapsMenu = "SelectMap";

    public void PauseGame()
    {

        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }

    public void ResumeGame()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset();

    }

    public void QuitToMainMenu()
    {

        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLevel);
    }

	public void QuitToMapsMenu(){

		Time.timeScale = 1f;
		Application.LoadLevel (mapsMenu);
	}

}
