using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour {
    NavMeshAgent navMeshAgent;
    public float timeForNewPath;

    bool inCoRoutine;
	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        if (!inCoRoutine)
            StartCoroutine(DoSomething());
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }
	
    IEnumerator DoSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
    }

    void GetNewPath()
    {
        navMeshAgent.SetDestination(getNewRandomPosition());
    }
	// Update is called once per frame

}
