using UnityEngine;
using System.Collections;
using System.Reflection.Emit;
using UnityEngine.UI;
using System.Xml.Linq;

public class PlatformerGenerator : MonoBehaviour
{

    public GameObject thePlatform;                          // la plataforma
    public Transform generationPoint;                       // el punto donde se generan
    public float distanceBetween;                           // la distancia entre la plataforma y el punto de generacion


    private float platformWidth;                            // el ancho de la plataforma

    public float distanceBetweenMin;                        // distancia minima entre la plataforma y el punto de generacion  
    public float distanceBetweenMax;                        // distancia maxima entre la plataforma y el punto de generacion

    //public GameObject[] thePlatforms;						// arreglo que contiene las plataformas 
    private int platformSelector;                           // random que selecciona la plataforma en el arreglo 
    public ObjectPooler[] theObjectPools;                   // crea un arreglo tipo ObjectPooler(script) de los objetos agrupados 

    private float[] platformWidths;                         // crea un vector con la anchura de las plataformas		

    private float minHeight;                                // altura minima
    public Transform maxHeightPoint;                        // objeto que determina la altura maxima tipo transform(escalado, traslacion, rotacion)  
    private float maxHeight;                                // altura maxima
    private float heightChange;                             // cambio de la altura


    public float maxHeigthChange;                           // cambio maximo de la altura

    public CoinGenerator theCoinGenerator;

    public float randomCoinThreshold;

	public float randomSpikeThreshold;
	public ObjectPooler spikePool;


    // Use this for initialization
    void Start()
    {

        //platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

        // se le asigna al arreglo la misma longitud de la lista de los objetos agrupados
        platformWidths = new float[theObjectPools.Length];

        // recorre el arreglo segun su longitud 
        for (int i = 0; i < theObjectPools.Length; i++)
        {

            // va a obtener de cada objeto su boxCollider con el tamaño en la posicion x 
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;

            // la minima altura sera la poscion actual
            minHeight = transform.position.y;
            // la maxima altura sera la posicion en y del objeto en la escena
            maxHeight = maxHeightPoint.position.y;

            theCoinGenerator = FindObjectOfType<CoinGenerator>();

        }

    }

    // Update is called once per frame
    void Update()
    {


        // si este objeto (en la mitad de la ultima plataforma) es menor que el pto de generacion(afuera de la camara)
        if (transform.position.x < generationPoint.position.x)
        {
            // la distancia entre este objeto(la plataforma) y el punto de generacion va a ser un numero random entre los valores min y max 
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);  //
                                                                                     // se selecciona una plataforma random desde la posicion 0 hasta el tamaño del arreglo de las plataformas 
            platformSelector = Random.Range(0, theObjectPools.Length);
            // el cambio de altura sera un numero random entre el maximo cambio de altura y su opuesto
            heightChange = transform.position.y + Random.Range(maxHeigthChange, -maxHeigthChange);

            // CONDICIONAL QUE LIMITA EL CAMBIO DE LAS ALTURAS PARA QUE ASI NO ESTEN FUERA DE CAMARA 

            // si el cambio de altura es mayor a la maxima altura 
            if (heightChange > maxHeight)
            {
                // el cambio de altura sera el maximo cambio 
                heightChange = maxHeight;
                // si no y si el cambio de altura es menor a la altura minima 
            }
            else if (heightChange < minHeight)
            {
                // el cambio de altura sera el la minima altura 
                heightChange = minHeight;
            }

            // la posicion de este objeto sera el mismo MAS el ancho de esta plataforma y la distancia de esta misma hasta el pto de generacion 
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, 0);

            // instancia (crea) las plataformas que se han seleccionado arbitrariamente desde el arreglo de las plataformas 
            //Instantiate (/*thePlatform */thePlatforms[platformSelector], transform.position, transform.rotation);


            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;

            newPlatform.SetActive(true);

			// generamos las monedas de manera random
			if (Random.Range(0f, 100f) < randomCoinThreshold){
            
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

			if (Random.Range (0f, 100f) < randomSpikeThreshold) {
			
				GameObject newSpike = spikePool.GetPooledObject ();

				float spikeXPosition = Random.Range (-platformWidths[platformSelector] / 2 + 1, platformWidths[platformSelector] / 2 - 1);



				Vector3 spikePosition = new Vector3 (spikeXPosition, 0.5f, 0f);

				newSpike.transform.position = transform.position + spikePosition;
				newSpike.transform.rotation = transform.rotation;
				newSpike.SetActive (true);
			}

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, 0);
        }

    }
}
