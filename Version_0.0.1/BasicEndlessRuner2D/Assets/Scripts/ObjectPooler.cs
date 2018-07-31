using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{

    public GameObject pooledObject;             // objeto que se encuentra en la escena y contiene el script

    public int pooledAmount;                    // cantidad de objetos agrupados 

    List<GameObject> pooledObjects;             // variable tipo lista de los objetos agrupados 


    // Use this for initialization
    void Start()
    {

        pooledObjects = new List<GameObject>();         // Instancia de la variable tipo lista 

        for (int i = 0; i < pooledAmount; i++)
        {               // se recorre la lista segun la cantidad de objetos agrupados
                        // casteo
            GameObject obj = (GameObject)Instantiate(pooledObject);     // instancia cada objeto  
            obj.SetActive(false);                                       // se desactiva cada objeto
            pooledObjects.Add(obj);                                 // se inserta cada objeto en la lista 
        }
    }

    // Metodo que obtiene cada objeto agrupado 
    public GameObject GetPooledObject()
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {               // se reorre la lista segun la cuenta de los objetos 

            if (!pooledObjects[i].activeInHierarchy)
            {               // si cada objeto de la lista en la jerarquia no esta activo

                return pooledObjects[i];                            // retorne cada objeto 
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject); // instancia todos los objetos inactivos en la lista
        obj.SetActive(false);                                       // se desactiva cada objeto
        pooledObjects.Add(obj);                                 // se inserta cada objeto en la lista 
        return obj;                                                 // retorne el objeto 
    }
}
