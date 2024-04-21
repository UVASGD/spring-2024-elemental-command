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
        if(logicElements.Length == 0 || !logicElements[0])
        {
            Debug.LogWarning(gameObject + " does not have any logic connected to it. Make sure to set it in ElementPowerer");
        }
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

            // wwise sound element changes
            if (poweredElement == ElementManager.Element.Air){
                AkSoundEngine.PostEvent("Play_Air_Sound", gameObject);
            }
            if (poweredElement == ElementManager.Element.Earth){
                AkSoundEngine.PostEvent("Play_Earth_Sound", gameObject);
            }
            if (poweredElement == ElementManager.Element.Ice){
                AkSoundEngine.PostEvent("Play_Ice_Freeze", gameObject);
            }
        }
        //Close the door if conditions are not met and its open
        else if(!conditionsMet && powered)
        {
            em.ChangeState(ElementManager.Element.None);
            AkSoundEngine.PostEvent("Play_Normal_Sound", gameObject);
            powered = false;
        }
    }
}
