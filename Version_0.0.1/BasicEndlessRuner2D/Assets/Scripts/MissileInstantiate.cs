using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInstantiate : MonoBehaviour {

    public GameObject prefab;


    [SerializeField]
    private float InstantiationTimer = 2f;


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        CreatePrefab();

    }

    void CreatePrefab()
    {

        InstantiationTimer -= Time.deltaTime;

        if (InstantiationTimer <= 0)
        {

            Instantiate(prefab, transform.position, Quaternion.identity);
            InstantiationTimer = 2f;
        }
    }
}
