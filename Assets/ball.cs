using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
     public Rigidbody rb;
     public float speed;
     public float rollThreshold = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if the magnitude of velocity is above the threshold
        if (rb.velocity.magnitude >= speed && rb.velocity.magnitude >= rollThreshold)
        {
            // Play sound here
            // AkSoundEngine.PostEvent("Play_SphereRoll", gameObject);
        }
    }

    //void OnCollisionStay(Collision collisionInfo){
    //        if(rb.velocity.magnitude >= speed){
    //            //play sound here 
    //            // AkSoundEngine.PostEvent("Play_SphereRoll", gameObject);
    //        }
    //    }
}
