using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_shoot : MonoBehaviour {

    GameObject prefab;
	// Use this for initialization
	void Start () {
        prefab = Resources.Load("magicshot") as GameObject;
	}
	
	// Update is called once per frame
        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

    }