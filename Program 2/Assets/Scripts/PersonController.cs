using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    Transform[] pathStack;
    bool gettingWater = false;
    bool shopping = false;
    bool homeless = true;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BringWater(Transform wellPosition)
    {
        gettingWater = true;

        //SetDestination(wellPosition.position);
        //find water 
        //find best path
        //come back
    }
    public void Shop(Transform shopPosition)
    {
        shopping = true;
        //move to shop
        //come back
    }

    public void GoTo(Vector3 destination)
    {
        agent.SetDestination(destination);
    }


    //private FindBestRouteA()
    //{}
 
}
