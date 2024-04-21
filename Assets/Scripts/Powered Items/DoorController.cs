using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.iOS;

public class DoorController : MonoBehaviour, ILogicReceiver
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private LogicElement[] logicElements;

    private bool doorOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        //warns if no elements are set
        if(logicElements.Length == 0 || !logicElements[0])
        {
            Debug.LogWarning(gameObject + " does not have any logic connected to it. Make sure to set it in DoorController");
        }
        UpdateLogic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Logic elements call this to update the door and open or close it if required
    public void UpdateLogic(){

        bool conditionsMet = true;
        foreach (LogicElement element in logicElements)
        {
            if(!element.GetCondition())
            {
                conditionsMet = false;
                break;
            }
        }

        //Open the door if conditions are met and its closed
        if (conditionsMet && !doorOpen)
        {
            doorOpen = true;
            myDoor.Play("DoorOpen", 0, 0.0f);
            AkSoundEngine.PostEvent("Play_SlidingDoor_Open", gameObject);
        }
        //Close the door if conditions are not met and its open
        else if(!conditionsMet && doorOpen)
        {
            myDoor.Play("DoorClose", 0, 0.0f);
            AkSoundEngine.PostEvent("Play_SlidingDoor_Close", gameObject);
            doorOpen = false;
        }
    }

}
