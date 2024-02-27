using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementManager : MonoBehaviour
{

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
        
    }

    // Update is called once per frame
    void Update()
    {
        //Air is 1
        if(Input.GetKeyDown(KeyCode.Alpha1) && state != Element.Air)
        {
            ChangeState(Element.Air);
        }
        //Earth is 2
        else if(Input.GetKeyDown(KeyCode.Alpha2) && state != Element.Earth)
        {
            ChangeState(Element.Earth);
        }
        //Ice is 3
        else if(Input.GetKeyDown(KeyCode.Alpha3) && state != Element.Ice)
        {
            ChangeState(Element.Ice);
        }
        //Electricity is 4
        else if(Input.GetKeyDown(KeyCode.Alpha4) && state != Element.Electricity)
        {
            ChangeState(Element.Electricity);
        }
        //None is Q
        else if(Input.GetKeyDown(KeyCode.Q) && state != Element.None) 
        {
            ChangeState(Element.None);
        }
    }

    public void ChangeState(Element newState)
    {
        //Undo the current state
        switch(state)
        {
            case Element.Air:
                UndoAir();
                break;
            case Element.Earth:
                UndoEarth();
                break;
            case Element.Ice:
                UndoIce();
                break;
            case Element.Electricity:
                UndoElectricity();
                break;
            case Element.None:
                UndoNone();
                break;
        }

        //call the relevant newState
        switch(newState)
        {
            case Element.Air:
                StartAir();
                break;
            case Element.Earth:
                StartEarth();
                break;
            case Element.Ice:
                StartIce();
                break;
            case Element.Electricity:
                StartElectricity();
                break;
            case Element.None:
                StartNone();
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
        foreach (GravityPlatform platform in FindObjectsOfType<GravityPlatform>())
        {
            platform.ActivateAir();
        }
    }

    private void UndoEarth()
    {
        foreach(FloorButton button in FindObjectsOfType<FloorButton>())
        {
            button.EndEarth();
            button.UpdateLogic();
        }
        foreach (GravityPlatform platform in FindObjectsOfType<GravityPlatform>())
        {
            platform.EndEarth();
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

    private void UndoIce()
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
    }

    private void StartIce()
    {
        filter.color = iceColor;
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

    private void UndoElectricity()
    {
        foreach (AlternatingPowerLogicElement alt in FindObjectsOfType<AlternatingPowerLogicElement>())
        {
            alt.EndElectricity();
        }
        return;
    }

    private void StartElectricity()
    {
        filter.color = electricityColor;
        foreach(AlternatingPowerLogicElement alt in FindObjectsOfType<AlternatingPowerLogicElement>())
        {
            alt.ActivateElectricity();
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
