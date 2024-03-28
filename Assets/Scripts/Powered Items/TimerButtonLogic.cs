using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerButtonLogic : MonoBehaviour

{
    [SerializeField] private LogicElement logic;
    [SerializeField] private float timerDuration = 5.0f;
    [SerializeField] private Animator anim;
    private bool timer_is_pressable = true;
    private bool has_been_pressed = false;
    private bool notIce = true;
    private float timer = 5.0f;
    [SerializeField] private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!timer_is_pressable) 
        {
            if(has_been_pressed && notIce)
            {
                timer -= Time.deltaTime; 
            }
        
        }

        if (timer < 0)
        {
            Debug.Log("timer depressed");
            timer_is_pressable = true;
            timer = timerDuration;
            has_been_pressed = false;
            anim.Play("TimerButtonRelease", 0, 0.0f);
            logic.SetInactive();
        }

    }

    public void PressButton()
    {
        if(timer_is_pressable){            
            timer_is_pressable = false;
            has_been_pressed = true;
            logic.SetActive();
            timer -= Time.deltaTime;
            anim.Play("TimerButtonPress", 0, 0.0f);
        }

    } 

    public void ActivateIce()
    {
        notIce = false;
        timer_is_pressable = false;
    }

    public void EndIce()
    {
        notIce = true;
        timer_is_pressable = !has_been_pressed;
    }

    }   