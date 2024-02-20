using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LogicElement : MonoBehaviour
{
    private bool conditionMet = false;
    [SerializeField] private GameObject receiverGameObject = null;

    private ILogicReceiver receiver = null;


    // Start is called before the first frame update
    void Start()
    {

        if(receiverGameObject == null || receiverGameObject.GetComponent<ILogicReceiver>() == null)
        {
            Debug.LogWarning(gameObject + " is not attached to a receiver. Make sure to set in LogicElement and ensure it has a ILogicReceiver implementation");

        } else if (receiverGameObject.GetComponent<ILogicReceiver>() != null)
        {
            receiver = receiverGameObject.GetComponent<ILogicReceiver>();
        }
    }

    public void SetActive()
    {
        conditionMet = true;
        receiver.UpdateLogic();
    }

    public void SetInactive()
    {
        conditionMet = false;
        receiver.UpdateLogic();
    }

    public bool GetCondition(){
        return conditionMet;
    }

}
