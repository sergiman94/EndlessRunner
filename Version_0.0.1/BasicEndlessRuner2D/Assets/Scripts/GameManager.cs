using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{


    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

	public bool powerupReset;

    // Use this for initialization
    void Start()
    {

        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();

       
    }

    void Update()
    {



    }


    public void RestartGame()
    {

        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        theDeathScreen.gameObject.SetActive(true);
      

        //StartCoroutine ("RestartGameCo");

    }

    public void Reset()
    {

        theDeathScreen.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {

            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;


		powerupReset = true;

    }

    /* public IEnumerator RestartGameCo(){

		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (1.0f);
		platformList = FindObjectsOfType<PlatformDestroyer> ();

		for (int i = 0; i < platformList.Length; i++) {
		
			platformList [i].gameObject.SetActive (false); 
		}

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	
	
	} */


}
