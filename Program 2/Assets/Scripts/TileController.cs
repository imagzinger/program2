using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileController : MonoBehaviour
{
    //public TileController[] neighbors = new TileController[8];
    private const int MAX_CHILDREN = 8;
    private const int MAX_PATH = 20;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject getTile(int col, int row)
    {
        return self.transform.FindChild("Col(" + col + ")").FindChild(row.ToString()).gameObject;
    }
    public GameObject[] AStar(GameObject startTile, GameObject endTile)
    {
        //double minDist = shortestDist(startTile.transform, endTile.transform);
        double[] costTotal = new double[MAX_PATH];
        double[] costToHere = new double[MAX_PATH];
        double[] costToEnd = new double[MAX_PATH];
        int numInOpen = 0;
        int closedPtr = 0;
        int q;
        int cost;
        int index;
        int index2;
        GameObject qTile;
        GameObject[] open = new GameObject[MAX_PATH];
        GameObject[] closed = new GameObject[MAX_PATH];
        GameObject[] children = new GameObject[MAX_CHILDREN];
        open[0] = startTile;
        numInOpen++;
        costToHere[0] = 0;
        costToEnd[0] = shortestDist(startTile.transform, endTile.transform);
        costTotal[0] = costToEnd[0] + costToHere[0];//can set this to zero 

        while (numInOpen > 0)
        {
            q = FindLowestF(costTotal,numInOpen);
            qTile = open[q];
            open[q] = null;
            children = FindChildren(qTile, self);
            numInOpen--;
            for (int i = 0; i < MAX_CHILDREN; i++)
            {

                if (children[i].transform.position == endTile.transform.position)
                {
                    closed[closedPtr++] = qTile;
                    closed[closedPtr++] = children[i];
                    return closed;
                }

                //set cost to current, cost from current to end, total cost and cost to move to current from previous
                cost = GetCost(children[i]);
                costToHere[i] = costToHere[closedPtr] + cost;
                costToEnd[i] = shortestDist(qTile.transform, endTile.transform);
                costTotal[i] = costToHere[i] + costToEnd[i];

                index  = NodeInList(qTile,open,numInOpen);
                index2 = NodeInList(qTile, closed, closedPtr);
                //if the node is in either close or open with a lower costTotal
                if (!(index != -1 && costTotal[i] < costTotal[index] || index2 != -1 && costTotal[i] < costTotal[index2]))
                {
                    //add child[i] to open
                    open[++numInOpen] = children[i];
                }
            }
            closed[closedPtr++] = qTile;
        }
        return null;
    }

    //returns the cost of traveling to that tile based on the tag that tile has
    private int GetCost(GameObject tile)
    {
        String tag = tile.transform.GetChild(0).gameObject.tag;
        if (tag == "road")
        {
            return 1;
        }
        else if (tag == "grass")
        {
            return 3;
        }
        else
        {
            return 2147483647;
        }

    }
    //returns the index if the node if it already exists if not returns -1
    private int NodeInList(GameObject tile, GameObject[] open, int size)
    {
        bool xMatch = false;
        bool zMatch = false;

		for (int i = 0; i < size; i++)
		{
            //check if X and Z position are the same if so they must be the same object
            xMatch = (open[i].transform.GetChild(0).position.x == tile.transform.GetChild(0).position.x);
            zMatch = (open[i].transform.GetChild(0).position.z == tile.transform.GetChild(0).position.z);
            if (xMatch && zMatch)
                return i;
		}
        return -1;
    }
    //returns the index of f that is the smallest
    private int FindLowestF(double[] costTotal, int size)
    {
        int minI = 0;
        double min = costTotal[0];
		for (int i = 1; i < size; i++)
		{
            if (costTotal[i] < min)
			{
                minI = i;
			}
		}
        return minI;
    }
    //returns the answer to the dist formula
    private double shortestDist(Transform start, Transform end) 
    {
        double xDiff2 = (start.position.x - end.position.x)*(start.position.x - end.position.x);
        double zDiff2 = (start.position.z - end.position.z)*(start.position.z - end.position.z);
        return Math.Sqrt(xDiff2 + zDiff2);
    }
    //returns an array of children from the parent node
    private GameObject[] FindChildren(GameObject tile, GameObject self)
    {
        GameObject[] neighbors = new GameObject[MAX_CHILDREN];
        string name = tile.name;
        int row = Int32.Parse(name);
        int col = Convert.ToInt32(tile.transform.parent.gameObject.name[5]);
        int index = 0;
		for (int i = -1; i < 2; i++)
		{
            for (int j = -1; j < 2; j++)
            {
                if (i != 0 && j != 0)
                {
                    neighbors[index++] = getTile(col + i, row + j);
                }
            }
        }
        return neighbors;
    }
}
