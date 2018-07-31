using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public PlayerController thePlayer;               // variable que contiene el componente PlayerController del jugador (the player)

    private Vector3 lastPlayerPosition;             // vector con la ultima posicion del jugador 

    private float distanceToMove;                   // distancia para moverse 


    // Use this for initialization
    void Start()
    {


        thePlayer = FindObjectOfType<PlayerController>();   // al iniciar verificamos si el jugador contiene el script
        lastPlayerPosition = thePlayer.transform.position;  // al iniciar tomamos la posicion del jugador como la ultima

    }

    // Update is called once per frame
    void Update()
    {

        // restamos la posicion actual con la anterior 
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        // creamos un nuevo vector adicionandole la distancia para moverse 
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        // actualizamos la ultima posicion con la actual 
        lastPlayerPosition = thePlayer.transform.position;
    }
}
