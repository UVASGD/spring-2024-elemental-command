using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    [SerializeField] private LogicElement logic;
    private ElementManager em;
    private float objectsRequired;
    public float baseObjectsRequired = 1.0f;
    private int objectsOn;
    [SerializeField] private float powerDelay;
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        em = FindObjectOfType<ElementManager>();
        if (!logic)
            logic = gameObject.GetComponent<LogicElement>();
        objectsOn = 0;
        objectsRequired = baseObjectsRequired;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        objectsOn += 1;
        UpdateLogic();
    }
    private void OnCollisionExit(Collision other) {
        objectsOn -= 1;
        //Idk how this could happen but just in case
        if(objectsOn < 0)
        {
            objectsOn = 0;
        }       
        UpdateLogic();
    }

    //This weird delay stuff keeps it from jittering on button presses
    public void UpdateLogic()
    {
        if (objectsOn >= objectsRequired && !logic.GetCondition())
        {
            Invoke("PowerOn", powerDelay);
        }
        else if (objectsOn < objectsRequired && logic.GetCondition())
        {
            Invoke("PowerOff", powerDelay);
        }

    }
    private void PowerOn()
    {
        if (em.state != ElementManager.Element.Ice)
        {
            if (objectsOn >= objectsRequired)
            {
                logic.SetActive();
                anim.Play("ButtonPressed", 0, 0.0f);
                CancelInvoke();
            }
        }
        
    }

    private void PowerOff()
    {
        if (em.state != ElementManager.Element.Ice)
        {
            if (objectsOn < objectsRequired)
            {
                logic.SetInactive();
                anim.Play("ButtonDepressed", 0, 0.0f);
                CancelInvoke();
            }
        }
        
    }

    public void ActivateEarth()
    {
        objectsRequired /= 2;
    }

    public void EndEarth()
    {
        objectsRequired = baseObjectsRequired;
    }

    public void EndIce()
    {
        UpdateLogic();
    }

}
