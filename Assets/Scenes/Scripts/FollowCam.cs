using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    public float camZ;
    public float easing = 0.05f;
    public UnityEngine.Vector2 minXY = UnityEngine.Vector2.zero;
    private void Awake()
    {
        camZ = this.transform.position.z;
    }
    private void FixedUpdate()
    {
        //if (POI == null) return;
        //UnityEngine.Vector3 destination = POI.transform.position;
        UnityEngine.Vector3 destination;
        if (POI==null)
        {
            destination = UnityEngine.Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;
            if(POI.tag=="Projectile")
            {
                if(POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                    return;
                }
            }
        }
        //destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = UnityEngine.Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
