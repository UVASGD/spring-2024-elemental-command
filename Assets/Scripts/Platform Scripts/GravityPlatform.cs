using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
{
    public Rigidbody rb;

    public Transform normalHeight;
    public Transform airHeight;
    public Transform earthHeight;
    
    private float initialHeight;
    private float highHeight;
    private float lowHeight;
    
    private float targetHeight;
    private float forceFactor = 1.0f;

    private Vector3 accumulatedForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        initialHeight = normalHeight.position.y;
        highHeight = airHeight.position.y;
        lowHeight = earthHeight.position.y;

        targetHeight = initialHeight;
        setPosition(targetHeight);
    }

    void Update()
    {
        if (targetHeight - 0.1 < transform.position.y && transform.position.y < targetHeight + 0.1)
        {
            rest();
            setPosition(targetHeight);
        }
        rb.freezeRotation = true;
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    public void ActivateAir()
    {
        targetHeight = highHeight;
        if (forceFactor > 1.0)
        {
            if (accumulatedForce.y == 0.0f) {
                rise(0.75f);
            } else {
                rise(0.25f);
            }
        } 
    }

    public void EndAir()
    {
        targetHeight = initialHeight;
    }

    public void ActivateEarth()
    {
        if (targetHeight != lowHeight) {
            targetHeight = lowHeight;
        }
    }

    public void EndEarth()
    {
        targetHeight = initialHeight;
        /* if (transform.position.y <= lowHeight) {
            rise(1.0f);
        }  */
        rise(1.0f);
    }

    public void EndIce()
    {
        targetHeight = initialHeight;
        if (transform.position.y < initialHeight) {
            EndEarth();
        }
    } 

    private void setPosition(float height)
    {
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }

    private void rest()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        accumulatedForce = rb.GetAccumulatedForce();
    }

    private void rise(float adjustment)
    {
        rb.AddForce(transform.up * forceFactor * adjustment * 9.81f, ForceMode.Impulse); 
        accumulatedForce = rb.GetAccumulatedForce();
    }
    

    private void OnCollisionEnter(Collision other)
    {
        forceFactor += 1.0f;
    }

    private void OnCollisionExit(Collision other)
    {
        forceFactor -= 1.0f;
    }
    
}


/*  GravityPlatform Code Version 1.0. Please leave this code alone in case any future versions fail.
private float maxHeight;
private float minHeight;
private float heightChange;
private float seconds;


void Start()
{
    maxHeight = 1.00f;
    minHeight = 0.95f;
}

void Update()
{
    if (seconds < 0.05)
    {
        seconds += Time.deltaTime;
    }
    else
    {
        if (transform.position.y > maxHeight)
        {
            heightChange = -0.01f;
        }
        else if (transform.position.y < minHeight)
        {
            heightChange = 0.01f;
        }
        else
        {
            heightChange = 0.0f;
        }
        transform.position += new Vector3(0, heightChange, 0);
        seconds = 0.0f;
    }
}
public void ActivateAir()
{
    maxHeight = 3.00f;
    minHeight = 2.95f;
    seconds = 0.0f;
}
public void EndAir()
{
    maxHeight = 1.00f;
    minHeight = 0.95f;
    seconds = 0.0f;
}

public void ActivateEarth()
{
    maxHeight = 0.15f;
    minHeight = 0.10f;
    seconds = 0.0f;
}
public void EndEarth()
{
    maxHeight = 1.00f;
    minHeight = 0.95f;
    seconds = 0.0f;
} */