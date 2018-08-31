using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{


    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private static ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

	public bool powerupReset;

    public StatusIndicator thePlayerStatusIndicator;



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

        if (thePlayer != null){

            thePlayer.enabled = true;
            Player.PlayerStats.curHealth = Player.PlayerStats.maxHealth;

            thePlayerStatusIndicator.SetHealth(Player.PlayerStats.curHealth, Player.PlayerStats.maxHealth);

        } 

        thePlayer.transform.position = playerStartPoint;

        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;


        powerupReset = true;



        

    }

    public void KillPlayer(Player player){

        //Destroy(player.gameObject);

        player.enabled = false;

    
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
