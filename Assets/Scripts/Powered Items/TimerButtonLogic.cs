using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButtonLogic : MonoBehaviour

{
    [SerializeField] private LogicElement logic;
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float timerDuration = 5.0f;
    private bool timer_is_pressable = true;
    private bool has_been_pressed = false;
    private float timer = 5.0f;
    private GameObject heldObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer_is_pressable){

            if(Input.GetKeyDown(KeyCode.E)){
            
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    timer_is_pressable = false;
                    has_been_pressed = true;
                    logic.SetActive();
                    timer -= Time.deltaTime;
                }

            } 
        } else {
            if(has_been_pressed){
                timer -= Time.deltaTime; 
            }
        
        }

        if (timer < 0){
            timer_is_pressable = true;
            timer = timerDuration;
            has_been_pressed = false;
            logic.SetInactive();
        }

    }
        
    }

