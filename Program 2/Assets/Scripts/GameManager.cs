using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int population = 1;
    public GameObject personPrefab;
    public TileController tileMap;
    public Transform[] pathStack;
    public HouseController[] house;
    //private int costPath = 1;
    //private int costGrass = 3;
    //private int costBuilding = 500;// its cheaper to walk around the entire space than go thru thise lol
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("AddPeople", 1.0f, 1.0f);
    }

    void AddPeople()
    {
        //for all houses
        //Random rnd = new Random();
        GameObject startTile;
        int x;
        for (int i = 0; i<6; i++ ) {
            //if house.full == false
            if (!house[i].IsFull())
            {
                population++;
                x = Random.Range(0,9);
                startTile = tileMap.getTile(x, 9);
                GameObject peep = Instantiate(personPrefab,startTile.transform.position, Quaternion.identity)/*.assignhouse?*/;
                int houseNum = AssignHouse(peep);
                //travel to that house
                SendToHouse(peep, houseNum, startTile);
            }
        }
            //
        //
    }

    void SendToHouse(GameObject peep, int houseNum, GameObject start)
    {
        GameObject[] path = tileMap.AStar(start, house[houseNum].transform.parent.gameObject);
		for (int i = 0; i < path.Length; i++)
		{
            StartCoroutine(FollowPath(peep.GetComponent<PersonController>(),path[i]));
        }
    
    }
    IEnumerator FollowPath(PersonController peep, GameObject destination)
    { 
        yield return new WaitForSeconds(1.0f);
        peep.GoTo(destination.transform.position);
    }
    int AssignHouse(GameObject peep)
    {
		for (int i = 0; i < 6; i++)
		{
            if(house[i].NPCs < 2)
			{
                house[i].household[house[i].NPCs] = peep;
                house[i].NPCs++;
                return i;
			}
		}
        for (int i = 0; i < 6; i++)
        {
            if (house[i].NPCs < house[i].maxNPC)
            {
                house[i].household[house[i].NPCs] = peep;
                house[i].NPCs++;
                return i;
            }
        }
        return -1;
    }
}
