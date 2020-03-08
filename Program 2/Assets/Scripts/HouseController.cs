using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{ 
    public int pints = 0;
    public int meals = 0;
    public int maxNPC = 2;
    

    public GameObject[] household = new GameObject[6];
    public int NPCs = 0;
    [SerializeField] Material needWater;
    [SerializeField] Material needFood;
    [SerializeField] Material needNPC;
    [SerializeField] Material needNothing;
    private int matCase;

    // Start is called before the first frame update
    void Start()
    {
        //household = new GameObject[6];
    }

    // Update is called once per frame
    void Update()
    {
        matCase = 0;

        if (pints > 0)
        {
            maxNPC = 4;
            if (meals > 0)
            {
                maxNPC = 6;
            }
			else
			{
                matCase = 1;
                GetFood();
            }
        }
		else
		{
            matCase = 2;
            GetWater();
        }
        if (NPCs == 0)
        {
            matCase = 3;
        }
		switch (matCase)
		{
            case 0:
                GetComponent<MeshRenderer>().material = needNothing;
                break;
            case 1:
                GetComponent<MeshRenderer>().material = needFood;
                break;
            case 2:
                GetComponent<MeshRenderer>().material = needWater;
                break;
            case 3:
                GetComponent<MeshRenderer>().material = needNPC;
                break;
        }


		
    }
    public bool IsFull()
    {
        Debug.Log(NPCs);
        return (NPCs >= maxNPC);
    }
    void GetFood() 
    { //assign person to get food
        //household[1].Shop();
        meals += 100;
    }
    void GetWater() 
    { //assign persond  to get water
      // household[0].BringWater();
        pints += 20;
    }
    void Feed() 
    {
        //subtract 1 water and 1 food
        meals--;
        pints--;
    }

    
    
}
