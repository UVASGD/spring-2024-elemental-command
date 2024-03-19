using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformTrigger : MonoBehaviour
{
    Vector3 lastPosition, lastMove;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        lastMove = transform.position - lastPosition;
        lastPosition = transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        if (!other.attachedRigidbody) return;
        other.attachedRigidbody.MovePosition(other.attachedRigidbody.position + lastMove);
    }


}
