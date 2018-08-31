using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameManager theGameManager;

    [System.Serializable]
    public static class PlayerStats
    {

        public static int maxHealth = 100;

        private static int _curHealth;
        public static  int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public static void init(){
            
            curHealth = maxHealth;
        
        }
    
    }

    //PlayerStats playerStats = new PlayerStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        PlayerStats.init();

        if (statusIndicator == null){

            Debug.LogError("No StatusIndicator referenced on player! ");

        }else{

            statusIndicator.SetHealth(PlayerStats.curHealth, PlayerStats.maxHealth);
        }

    }


    void Update()
    {

        //Debug.Log(playerStats.curHealth);

    }

    public void DamagePlayer(int damageAmount){
        

        PlayerStats.curHealth -= damageAmount;


        if (PlayerStats.curHealth <= 0) {

            theGameManager.KillPlayer(this);


        }

        statusIndicator.SetHealth(PlayerStats.curHealth, PlayerStats.maxHealth);

    }

}
