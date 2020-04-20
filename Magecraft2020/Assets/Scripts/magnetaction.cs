using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetaction : MonoBehaviour {
    //script for managing magnetism

    //Public Variables
    public Vector3 newPosition; //target pos

    //Private Variables
    private Transform trans; //transform

    private void Awake()
    {
        trans = transform;
    }

    private void Update()
    {
        trans.position = Vector3.Lerp(trans.position, newPosition, Time.deltaTime * 4f);

        if (Mathf.Abs(newPosition.x - trans.position.x) < 0.05)
            trans.position = newPosition;
        //this piece of code means that the object can actually reach the target position, due to the way lerping works
    }
}
