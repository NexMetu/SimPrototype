using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signalRaycast : MonoBehaviour {

    public int distanceMax;
    public int numStation;

    RaycastHit hit;

    void Start () {

	}
	
	void Update () {

        //Sends a rayCast and draws line for each baseStation
        foreach (Vector3 direction in baseStationDirection(numStation)){
            if (Physics.Raycast(transform.position, direction, out hit, distanceMax))
            {
                if (hit.collider.name == "testReciever")
                {
                    Debug.DrawRay(transform.position, direction, Color.blue);
                }
            }
        }

        
    }

    //Stores all baseStations relative to UE in an array
    private Vector3[] baseStationDirection(int numStations)
    {
        Vector3[] dirs = new Vector3[numStations];
        int k = 0;

        foreach (GameObject baseStation in GameObject.FindGameObjectsWithTag("baseStation"))
        {
            dirs[k] = baseStation.transform.position - transform.position;
            k++;
        }
        return dirs;
    }
}
