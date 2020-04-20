using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 1.0f;

    // Update is called once per frame
    void Start()
    {
        Destroy(this.gameObject, lifetime);
        //this one is real simple and is used to manage particles in the game so they don't stick around too long, just in case.
        //Anything with this script is destroyed after 1 second
    }
}
