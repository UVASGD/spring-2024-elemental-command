using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    private ElementManager em;

    private float timer = 0.0f;

    void Start()
    {
        em = FindObjectOfType<ElementManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (em.state != ElementManager.Element.Ice)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(pointA.position, pointB.position, (Mathf.Sin(timer) + 1) / 2);
        }
        
    }
    
}
