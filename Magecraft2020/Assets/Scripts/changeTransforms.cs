using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTransforms : MonoBehaviour {

    //create public variables
    public float size = 1.0f;
    public bool moving = false;
    public float moveSpeed = 0.1f;
    public float rotationSpeed = 1.0f;

    //create private variables
    private float currentScale = 0.0f;
    private float currentSize;



	
	// Update is called once per frame
	void Update () {
        float x = Random.Range(-5, 5);
        float z = Random.Range(-5, 5);

        if (currentScale < 1.0f){
            currentScale += 0.05f;
        }
        currentSize = currentScale * size;


        //------------------------------------------------------------------------------------------------
        //19 - Modifies Scale, Position, & Rotation of an object
        //------------------------------------------------------------------------------------------------
        transform.Rotate(rotationSpeed, rotationSpeed, rotationSpeed);
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);

        if (moving == true){
            transform.position += new Vector3((x) * moveSpeed, (0) * moveSpeed, (z) * moveSpeed);
        }
	}
}
