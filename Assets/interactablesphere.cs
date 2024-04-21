using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactablesphere : MonoBehaviour
{
    private bool isBeingHeld = false; //track if box is being held
    private float speed;
    private Rigidbody rigidBody;

    public void SetBeingHeld(bool held)
    {
        isBeingHeld = held;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>(); // initialize rigidBody
    }

    // Update is called once per frame
    void Update()
    {
        speed = rigidBody.velocity.magnitude;
        if (speed >= 0.8f && IsTouchingGround())
        {
            AkSoundEngine.SetState("Ball", "Rolling"); // Set state to Rolling if speed is sufficient and touching ground
        }

        else
        {
            AkSoundEngine.SetState("Ball", "Idle"); // Set state to Idle if speed is low
        }
    }

    private bool IsTouchingGround()
    {
        // Perform a sphere cast downwards to check if the sphere is touching the ground
        float radius = GetComponent<Collider>().bounds.extents.x * 0.9f; // Adjust the radius of the sphere cast to be slightly smaller than the sphere
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, radius, Vector3.down, out hit, 0.1f))
        {
            return true;
        }
        return false;
    }


    private void OnCollisionEnter(Collision other)

    {
        // check if box is being held and if collision is not with player
        if (!isBeingHeld && !other.collider.CompareTag("Player")){
            // put sound here 
        AkSoundEngine.PostEvent("Play_SphereDrop_Normal", gameObject);
        }
       
    }


}

