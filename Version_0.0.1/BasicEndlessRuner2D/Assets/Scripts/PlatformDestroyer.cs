using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour
{

    // punto de destrucccion 
    public GameObject platformDestructionPoint;


    // Use this for initialization
    void Start()
    {
        // encuentra y toma el punto de destruccion(gameobject)
        platformDestructionPoint = GameObject.Find("platformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        // si el punto de destruccion se encuentra en una posicion mayor en el eje x que la plataforma 
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            // desactivar el objeto
            gameObject.SetActive(false);
            //Destroy (gameObject);

        }
    }
}
