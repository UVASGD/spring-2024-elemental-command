using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ElementManager : MonoBehaviour
{

    [SerializeField] float cooldownTimer = 3f;

    private float ogTimer;

    public TextMeshProUGUI timerCooldownText;
     public Image backgroundTimerCooldown;

    private bool ableToChangeStates;
    public AudioSource AirStateChange;
    public AudioSource EarthStateChange;
    public AudioSource IceStateChange;
    public Color earthColor;
    public Color airColor;
    public Color iceColor;
    public Color electricityColor;
    public Color noneColor; 
    [SerializeField] private Image filter;

    public enum Element{
        None,
        Earth,
        Air,
        Ice,
        Electricity,
    }
    public Element state;

    
    // Start is called before the first frame update
    void Start()
    {
        // AkSoundEngine.SetState(" Music", "Normal"); //wwise set state to normal
        ogTimer = cooldownTimer;
        ableToChangeStates = true;
        UndoAir();
    }

    // Update is called once per frame
    void Update()
    {

        if (!ableToChangeStates){
            cooldownTimer -= Time.deltaTime;
            timerCooldownText.gameObject.SetActive(true);
            backgroundTimerCooldown.gameObject.SetActive(true);
            timerCooldownText.text = cooldownTimer.ToString("0.00");

            if (cooldownTimer < 0){
                cooldownTimer = ogTimer;
                ableToChangeStates = true;
            }
        } else {
            timerCooldownText.gameObject.SetActive(false);
            backgroundTimerCooldown.gameObject.SetActive(false);
        }
        




        ElementAvailability elementAvailability = GetComponent<ElementAvailability>();
        //Air is 1
        if(Input.GetKeyDown(KeyCode.Alpha1) && state != Element.Air && ableToChangeStates)
        {
            if(elementAvailability.Air_Available){
                ChangeState(Element.Air);
                // WWise air sound
                AkSoundEngine.PostEvent("Play_Air_Sound", gameObject);
                //AkSoundEngine.SetState(" Music", "Air"); 
            }
        }
        //Earth is 2
        else if(Input.GetKeyDown(KeyCode.Alpha2) && state != Element.Earth && ableToChangeStates)
        {
            if (elementAvailability.Earth_Available){
                ChangeState(Element.Earth);
                // WWise earth sound
                AkSoundEngine.PostEvent("Play_Earth_Sound", gameObject);
                //AkSoundEngine.SetState(" Music", "Earth"); 
            }
        }
        //Ice is 3
        else if(Input.GetKeyDown(KeyCode.Alpha3) && state != Element.Ice && ableToChangeStates)
        {
            if (elementAvailability.Ice_Available){
                ChangeState(Element.Ice);
                // WWise ice sound
                AkSoundEngine.PostEvent("Play_Ice_Freeze", gameObject);
                //AkSoundEngine.SetState(" Music", "Ice"); 
            }
        }
        //Electricity is 4 (and not active)
        // else if(Input.GetKeyDown(KeyCode.Alpha4) && state != Element.Electricity)
        // {
        //     ChangeState(Element.Electricity);
        // }
        //None is Q
        else if((Input.GetKeyDown(KeyCode.Q) && state != Element.None) ||
                (Input.GetKeyDown(KeyCode.Alpha3) && state == Element.Ice) ||
                (Input.GetKeyDown(KeyCode.Alpha2) && state == Element.Earth) ||
                (Input.GetKeyDown(KeyCode.Alpha1) && state == Element.Air)) 
        {
            if (elementAvailability.PlayerCanCancel){
                ChangeState(Element.None);
                // wwise normal sound
                AkSoundEngine.PostEvent("Play_Normal_Sound", gameObject);
            }
        }
    }

    public void ChangeState(Element newState)
    {
        ableToChangeStates = false;
        //Undo the current state
        switch(state)
        {
            case Element.Air:
                UndoAir();
                break;
            case Element.Earth:
                UndoEarth(newState);
                break;
            case Element.Ice:
                UndoIce(newState);
                break;
            case Element.None:
                UndoNone();
                break;
        }

        //call the relevant newState
        switch (newState)
        {
            case Element.Air:
                StartAir();
                //AkSoundEngine.SetSwitch("MusicSwitch", "Air", gameObject); // Set Wwise switch to Air
                //AkSoundEngine.SetState("Music", "Air"); // Set Wwise state to Air
                //AkSoundEngine.PostEvent("Play_MusicBlend", gameObject); // Trigger Wwise Event
                break;
            case Element.Earth:
                StartEarth();
                //AkSoundEngine.SetSwitch("MusicSwitch", "Earth", gameObject); // Set Wwise switch to Earth
                //AkSoundEngine.SetState("Music", "Earth"); // Set Wwise state to Earth
                //AkSoundEngine.PostEvent("Play_MusicBlend", gameObject); // Trigger Wwise Event
                break;
            case Element.Ice:
                StartIce();
                //AkSoundEngine.SetSwitch("MusicSwitch", "Ice", gameObject); // Set Wwise switch to Ice
                //AkSoundEngine.SetState("Music", "Ice"); // Set Wwise state to Ice
                //AkSoundEngine.PostEvent("Play_MusicBlend", gameObject); // Trigger Wwise Event
                break;
            case Element.None:
                StartNone();
                //AkSoundEngine.SetState("Music", "Normal"); // Set Wwise state to None
                //AkSoundEngine.PostEvent("Music_Change", gameObject); // Trigger Wwise Event
                break;
        }
        state = newState;
    }

    private void UndoAir()
    {
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        foreach (GravityPlatform platform in FindObjectsOfType<GravityPlatform>())
        {
            platform.EndAir();
        }
    }

    private void StartAir()
    {
        filter.color = airColor;
        Physics.gravity = new Vector3(0f, 1f, 0f);
        AirStateChange.Play();
        foreach (GravityPlatform platform in FindObjectsOfType<GravityPlatform>())
        {
            platform.ActivateAir();
        }
    }

    private void UndoEarth(Element newState)
    {
        foreach(FloorButton button in FindObjectsOfType<FloorButton>())
        {
            button.EndEarth();
            button.UpdateLogic();
        }
        if (newState != Element.Ice) {
            foreach (GravityPlatform platform in FindObjectsOfType<GravityPlatform>())
            {
                platform.EndEarth();
            }
        }
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
    }

    private void StartEarth()
    {
        filter.color = earthColor;
        foreach (FloorButton button in FindObjectsOfType<FloorButton>())
        {
            button.ActivateEarth();
            button.UpdateLogic();
        }
        foreach (GravityPlatform platform in FindObjectsOfType<GravityPlatform>())
        {
            platform.ActivateEarth();
        }
        Physics.gravity = new Vector3(0f, -19.62f, 0f);
    }

    private void UndoIce(Element newState)
    {
        foreach (Rigidbody toFreeze in FindObjectsOfType<Rigidbody>())
        {
            if (toFreeze.tag != "Player")
            {
                //don't tell me why this unlocks it some crazy bitwise stuff
                toFreeze.constraints &= ~RigidbodyConstraints.FreezePosition & ~RigidbodyConstraints.FreezeRotation;
            }
        }
        foreach(AlternatingPowerLogicElement alt in FindObjectsOfType<AlternatingPowerLogicElement>())
        {
            alt.EndIce();
        }
        foreach(FloorButton button in FindObjectsOfType<FloorButton>())
        {
            button.EndIce();
        }
        foreach(GravityPlatform platform in FindObjectsOfType<GravityPlatform>())
        {
            platform.rb.constraints = ~RigidbodyConstraints.FreezePositionY;
            if (newState != Element.Earth) {
                platform.EndIce();
            }
        }
    }

    private void StartIce()
    {
        filter.color = iceColor;
        IceStateChange.Play();
        foreach (Rigidbody toFreeze in FindObjectsOfType<Rigidbody>())
        {
            if (toFreeze.tag != "Player")
            {
                toFreeze.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            }
        }
        foreach (AlternatingPowerLogicElement alt in FindObjectsOfType<AlternatingPowerLogicElement>())
        {
            alt.ActivateIce();
        }
    }


    
    private void UndoNone()
    {
        return;
    }

    private void StartNone()
    {
        filter.color = noneColor;
    }

}
