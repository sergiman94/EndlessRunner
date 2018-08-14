using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollAndParallax : MonoBehaviour {


    public bool scrolling, parallax;

    public float backgroundSize;
    public float parallaxSpeeed;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;

        layers = new Transform[transform.childCount]; // creamos un arreglo con la cantidad de objetos del background
        for (int i = 0; i < transform.childCount; i++) // llenamos el arreglo con cada objeto
            layers[i] = transform.GetChild(i);

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }


    private void Update()
    {
        if (parallax){

            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeeed);

        }

        lastCameraX = cameraTransform.position.x;

        if (scrolling){

            if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            {
                ScrollLeft();
            }

            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            {
                ScrollRight();
            }

        }


    }

    // funciones que se crean si la camara va mucho a la derecha o mucho a la izquierda

    private void ScrollLeft(){

        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;

        if (rightIndex < 0)
            rightIndex = layers.Length - 1;

    }

    private void ScrollRight(){

        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + layers[rightIndex].position.y + backgroundSize);

        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length)
            leftIndex = 0;
        
    }



}
