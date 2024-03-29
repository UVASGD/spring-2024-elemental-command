using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPowerer : MonoBehaviour, ILogicReceiver
{

    private ElementManager em;
    [SerializeField] private ElementManager.Element poweredElement;
    [SerializeField] private LogicElement[] logicElements;
    private bool powered = false;

    // Start is called before the first frame update
    void Start()
    {
        em = FindObjectOfType<ElementManager>();
        UpdateLogic();
    }

    public void UpdateLogic()
    {
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
        if (conditionsMet && !powered)
        {
            powered = true;
            em.ChangeState(poweredElement);
        }
        //Close the door if conditions are not met and its open
        else if(!conditionsMet && powered)
        {
            em.ChangeState(ElementManager.Element.None);
            powered = false;
        }
    }
}
