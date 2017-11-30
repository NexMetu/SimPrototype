using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signalRaycast : MonoBehaviour
{

    public int distanceMax;

    RaycastHit hit;
    Vector3[] vertices = new Vector3[4];

    void Start()
    {
        
    }

    void Update()
    {

        //Sends a rayCast and draws line for each baseStation
        foreach (Vector3 direction in baseStationDirection())
        {
            if (Physics.Raycast(transform.position, direction, out hit, distanceMax))
            {
                if (hit.collider.tag == "baseStation")
                {
                    Debug.DrawRay(transform.position, direction, Color.blue);
                }
            }
        }

        /*foreach (Collider wall in wallsNearby())
        {
            if (wall.tag == "wall")
            {
                vertices[0] = wall.transform.position - new Vector3(wall.bounds.extents.x, wall.bounds.extents.y, wall.bounds.extents.z);
                vertices[1] = wall.transform.position - new Vector3(wall.bounds.extents.x, -wall.bounds.extents.y, wall.bounds.extents.z);
                vertices[2] = wall.transform.position - new Vector3(-wall.bounds.extents.x, wall.bounds.extents.y, wall.bounds.extents.z);
                vertices[3] = wall.transform.position - new Vector3(-wall.bounds.extents.x, -wall.bounds.extents.y, wall.bounds.extents.z);

                Vector3 dir = Vector3.Cross(vertices[0] - vertices[1], vertices[1] - vertices[2]);
                Vector3 norm = Vector3.Normalize(dir);

                Debug.DrawLine(wall.transform.position, wall.transform.position + dir);
            }
        }*/
    }

    //Stores all baseStations relative to UE in an array
    private List<Vector3> baseStationDirection()
    {
        List<Vector3> dirs = new List<Vector3>();
        int k = 0;

        foreach (GameObject baseStation in GameObject.FindGameObjectsWithTag("baseStation"))
        {
            dirs.Add(baseStation.transform.position - transform.position);
            k++;
        }
        return dirs;
    }

    /*private Collider[] wallsNearby()
    {
        Collider[] walls = Physics.OverlapSphere(transform.position, distanceMax);
        return walls;
    }*/

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach(Vector3 vert in vertices)
        {
            Gizmos.DrawSphere(vert, 0.2f);
        }
    }*/
}
