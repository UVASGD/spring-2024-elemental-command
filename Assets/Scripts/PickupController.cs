using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    private GameObject heldObj;
    private Rigidbody heldObjRB;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;
    [SerializeField] private float sharpness = 20;

    [SerializeField] private float unfreezeTimer = 1.0f;

    private ElementManager em;

    // Start is called before the first frame update
    void Start()
    {
        em = FindObjectOfType<ElementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    PickupObject(hit.transform.gameObject);

                }
            }else{
                DropObject();
            }
        }
        if(heldObj != null)
        {
            MoveObject();
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if(pickObj.GetComponent<Rigidbody>())
        {
            //this is where you adjust for what held objects look like
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
        //Resets rb to "Defaults"

        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;

        heldObjRB.constraints = RigidbodyConstraints.None;
        if(em.state == ElementManager.Element.Ice)
        {
            Invoke("DropFrozenObject", unfreezeTimer);
        }

        heldObjRB.transform.parent = null;
        heldObj = null;

    }

    void DropFrozenObject()
    {
        heldObjRB.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
            
        }

        Vector3 eulers = heldObj.transform.eulerAngles;

        //This still isn't working exactly how i'd like it, heres some stuff that kinda worked
        //Main issue is that I want it to keep facing forward and be flat, the MoveTowards keeps it flat but it spins when you look up/down
        //and idk how to change it so it doesn't spin, I tried a look target but idk whatever

        // if(Vector3.Distance(eulers, (transform.position - heldObj.transform.position).normalized) > 20f)
        // {
        //     heldObj.transform.LookAt(lookTarget);
        // }
        // eulers.x = 0f;
        // eulers.y = 0f;
        // heldObj.transform.eulerAngles = eulers;

        float step = sharpness * Time.deltaTime;
        heldObj.transform.eulerAngles = Vector3.MoveTowards(eulers, new Vector3(0, eulers.y, 0), step);


    }

}
