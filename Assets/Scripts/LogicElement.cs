using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicElement : MonoBehaviour
{
    private bool conditionMet = false;
    [SerializeField] private DoorController door = null;

    // Start is called before the first frame update
    void Start()
    {
        if(door == null)
        {
            Debug.LogWarning(gameObject + " is not attached to a door. Make sure to set in LogicElement");
        }
    }

    public void SetActive()
    {
        conditionMet = true;
        door.UpdateDoorLogic();
    }

    public void SetInactive()
    {
        conditionMet = false;
        door.UpdateDoorLogic();
    }

    public bool GetCondition(){
        return conditionMet;
    }

}
