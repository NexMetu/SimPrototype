using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class signalInefficientRaycast : MonoBehaviour {

    public int numRays;
    public int distanceMax;
    public float rayTime;
    public bool showAllRays;

    void Start () {
        //Updates once per every rayTime
        InvokeRepeating("rayCast", 0, rayTime);
    }

    void Update()
    {
    }

    //Some math formula which evenly distributes numberDirections around a sphere. 
    private Vector3[] getSphereDirections(int numDirections)
    {
        Vector3[] pts = new Vector3[numDirections];
        float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
        float off = 2f / numDirections;

        foreach (int k in Enumerable.Range(0, numDirections))
        {
            float y = k * off - 1 + (off / 2);
            float r = Mathf.Sqrt(1 - y * y);
            float phi = k * inc;
            float x = Mathf.Cos(phi) * r;
            float z = Mathf.Sin(phi) * r;
            pts[k] = new Vector3(x, y, z);
        }

        return pts;
    }

    void rayCast()
    {

        //Sends a rayCast in each direction of a point from the origin sphere.
        foreach (Vector3 direction in getSphereDirections(numRays))
        {
            RaycastHit hit;
            RaycastHit reflect;

            if(showAllRays == true)
            {
                Debug.DrawRay(transform.position, direction * distanceMax, Color.green, rayTime);
            }
            //Checks for a reflect that hits the testReciever object and draws a line.
            else if (Physics.Raycast(transform.position, direction, out hit, distanceMax) && !(hit.collider.CompareTag("badReflect")))
                {
                    Vector3 incomingDirection = hit.point - transform.position;
                    Vector3 reflectDirection = Vector3.Reflect(incomingDirection, hit.normal).normalized;

                    if (Physics.Raycast(hit.point, reflectDirection, out reflect, distanceMax))
                    {
                        if (reflect.collider.gameObject.name == "testReciever")
                        {
                            Debug.DrawRay(transform.position, direction * hit.distance, Color.green, rayTime);
                            Debug.DrawRay(hit.point, reflectDirection * reflect.distance, Color.green, rayTime);
                        }
                    }
                
            }
        }
    }

}
