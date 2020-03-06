using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    Transform[] pathStack;
    bool gettingWater = false;
    bool shopping = false;
    bool homeless = true;

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

    public void GoHome(Transform housePosition)
    {

    }

    //private FindBestRouteA()
    //{}
 
}
