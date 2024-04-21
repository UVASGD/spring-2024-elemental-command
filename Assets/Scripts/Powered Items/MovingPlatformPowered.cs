using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformPowered : MonoBehaviour, ILogicReceiver
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Transform platform;
    private ElementManager em;

    private bool movingUp = true; // WWise: flag to indicate the direction of movement
    private float timer = 0.0f;

    private bool powered;
    [SerializeField] private LogicElement[] logicElements;

    void Start()
    {
        em = FindObjectOfType<ElementManager>();
        platform.position = pointA.position;
        powered = false;
        if(logicElements.Length == 0 || !logicElements[0])
        {
            Debug.LogWarning(gameObject + " does not have any logic connected to it. Make sure to set it in MovingPlatformPowered");
        }
        UpdateLogic();
    }
    // Update is called once per frame
    void Update()
    {
        if (em.state != ElementManager.Element.Ice && powered)
        {
            timer += Time.deltaTime;
            platform.position = Vector3.Lerp(pointA.position, pointB.position, (Mathf.Sin(timer + (3 * Mathf.PI/2)) + 1) / 2);
            // wwise start event
            //AkSoundEngine.PostEvent("Play_PlatformMoveUp", gameObject);
        }
        
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

        //power if conditions are met and its off
        if (conditionsMet && !powered)
        {
            powered = true;
        }
        //cut power if conditions are not met and its powered
        else if(!conditionsMet && powered)
        {
            powered = false;
        }
    }

}
