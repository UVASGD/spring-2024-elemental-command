using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatform : MonoBehaviour
{
    // GravityPlatform Code Version 2.0
    // Creates an instance of a Rigidbody.
    // Rigidbodies are required to add forces to the platform and change its velocity.
    Rigidbody rb;
   
    // Sets the initial height of the platform and the base value of the force that will be used on platform when it rises.
    public float targetHeight = 1.5f;
    public float forceFactor = 1.0f;

    // Sets values for the three heights that the platform rises or falls to based on the element used.
    public float initialHeight = 1.5f;
    public float highHeight = 2.8f;
    public float lowHeight = 0.2f;

    void Start()
    {
        // Initializes the platform's Rigidbody 
        rb = GetComponent<Rigidbody>();
        // Sets the height of the platform to the current value of targetHeight
        setPosition(targetHeight);
    }

    // For each frame of the game...
    void Update()
    {
        // If the platform is close to its target height...
        if (targetHeight - 0.1 < transform.position.y && transform.position.y < targetHeight + 0.1)
        {
            // Call rest() to stop it for a second and then set its height to the targetHeight.
            // This prevents gravity (or lack thereof) from pulling the platform away from the targetHeight.
            rest();
            setPosition(targetHeight);
        }
    }

    // Sets the high height of the platform as its destination.
    public void ActivateAir()
    {
        targetHeight = highHeight;
    }

    // Sets the initial height of the platform as its destination.
    public void EndAir()
    {
        targetHeight = initialHeight;
    }

    // Sets the low height of the platform as its destination.
    public void ActivateEarth()
    {
        targetHeight = lowHeight;
    }

    // Sets the initial height of the platform as its destination.
    public void EndEarth()
    {
        targetHeight = initialHeight;
        rise();
    }

    // Places the platform at the position specified in the height parameter. 
    // Note: In Unity, this will happen immediately and anything on top of the platform will fall through, including the player!
    private void setPosition(float height)
    {
        transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }

    // Stops the platform from moving.
    private void rest()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
    }

    // Raises the platform for a second based on the number of objects currently on top of it.
    private void rise()
    {
        rb.AddForce(transform.up * forceFactor * 9.81f, ForceMode.Impulse);
    }

    // Increases the forceFactor by 1.0 when an object touches the platform.
    private void OnCollisionEnter(Collision other)
    {
        forceFactor += 1.0f;
    }

    // Decreases the forceFactor by 1.0 when an object stops touching the platform.
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