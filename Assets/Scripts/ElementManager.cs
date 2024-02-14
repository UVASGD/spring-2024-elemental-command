using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementManager : MonoBehaviour
{

    public Color earthColor;
    public Color airColor;
    public Color noneColor; 
    [SerializeField] private Image filter;

    public enum Element{
        None,
        Earth,
        Air
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

    private void UndoNone()
    {
        return;
    }

    private void StartNone()
    {
        filter.color = noneColor;
    }

}
