using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerButtonLogic : MonoBehaviour

{
    [SerializeField] private LogicElement logic;
    [SerializeField] private float timerDuration = 5.0f;
    [SerializeField] private Animator anim;
    private bool timer_is_pressable = true;
    private bool has_been_pressed = false;
    private float timer = 5.0f;
    [SerializeField] private Transform playerTransform;

    // wwise uint variable
    public uint TimerTicking;

    ElementManager em;
    // Start is called before the first frame update
    void Start()
    {

        em = FindObjectOfType<ElementManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!timer_is_pressable) 
        {
            if(has_been_pressed)
            {

                if (em.state == ElementManager.Element.Ice)
                {   //timer stays the same if button pressed and in ice
                    // Debug.Log("timer = " + timer);
                    return;
                }

                timer -= Time.deltaTime; 
            }
        
        }

        if (timer < 0)
        {
            timer_is_pressable = true;
            timer = timerDuration;
            has_been_pressed = false;
            anim.Play("TimerButtonRelease", 0, 0.0f);
            // wwise play timer button sound (end)
            AkSoundEngine.PostEvent("Play_TimerButton_End", gameObject);
            AkSoundEngine.StopPlayingID(TimerTicking); // stop ticking sound
            logic.SetInactive();
        }


    }

    public void PressButton()
    {
        if(timer_is_pressable && !(em.state == ElementManager.Element.Ice)){            
            timer_is_pressable = false;
            has_been_pressed = true;
            logic.SetActive();
            timer -= Time.deltaTime;
            anim.Play("TimerButtonPress", 0, 0.0f);
            
            // wwise play timer button sound (start and ticking)
            AkSoundEngine.PostEvent("Play_TimerButton_Start", gameObject);
            // TimerTicking = AkSoundEngine.PostEvent("Play_TimerButton_Ticking", gameObject);

        }

    } 
    }   