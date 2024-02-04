using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, (Mathf.Sin(Time.time)+1)/2);
    }
    
}
