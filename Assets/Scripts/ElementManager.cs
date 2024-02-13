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
    [SerializeField] private Element state;
    
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
                UndoElectrcity();
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
                StartElectrcity();
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
    }

    private void StartAir()
    {
        filter.color = airColor;
        Physics.gravity = new Vector3(0f, 1f, 0f);
    }

    private void UndoEarth()
    {
        foreach(FloorButton button in FindObjectsOfType<FloorButton>())
        {
            button.EndEarth();
            button.UpdateLogic();
        }
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
    }

    private void StartEarth()
    {
        filter.color = earthColor;
        foreach(FloorButton button in FindObjectsOfType<FloorButton>())
        {
            button.ActivateEarth();
            button.UpdateLogic();
        }
        Physics.gravity = new Vector3(0f, -19.62f, 0f);
    }

    private void UndoIce()
    {
        return;
    }

    private void StartIce()
    {
        filter.color = iceColor;
    }

    private void UndoElectrcity()
    {
        return;
    }

    private void StartElectrcity()
    {
        filter.color = electricityColor;
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
