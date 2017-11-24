using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class signalRaycast : MonoBehaviour {

    public int numRays;
    public int distanceMax;

    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        foreach(var direction in getSphereDirections(numRays)){

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit))
            {
                Vector3 incomingVec = hit.point - transform.position;
                Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);
                Debug.DrawRay(transform.position, direction * hit.distance);
                Debug.DrawRay(hit.point, reflectVec);
            }
        }
    }

    private Vector3[] getSphereDirections(int numDirections)
    {
        var pts = new Vector3[numDirections];
        var inc = Mathf.PI * (3 - Mathf.Sqrt(5));
        var off = 2f / numDirections;

        foreach (var k in Enumerable.Range(0, numDirections))
        {
            var y = k * off - 1 + (off / 2);
            var r = Mathf.Sqrt(1 - y * y);
            var phi = k * inc;
            var x = (float)(Mathf.Cos(phi) * r);
            var z = (float)(Mathf.Sin(phi) * r);
            pts[k] = new Vector3(x, y, z);
        }

        return pts;
    }

}
