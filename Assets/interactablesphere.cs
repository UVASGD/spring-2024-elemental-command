using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactablesphere : MonoBehaviour
{
    private bool isBeingHeld = false; //track if box is being held

    public void SetBeingHeld(bool held)
    {
        isBeingHeld = held;
    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
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

