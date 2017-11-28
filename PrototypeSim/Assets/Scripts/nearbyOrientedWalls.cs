using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearbyOrientedWalls : MonoBehaviour {

    public int distanceMax;

    void Start () {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, distanceMax);

        /*foreach(Vector3)
        float angle = 10
        if (Vector3.Angle(player.transform.forward, transform.position - player.transform.position) < angle)
        {
        }*/
    }
	
	void Update () {

    }
}
