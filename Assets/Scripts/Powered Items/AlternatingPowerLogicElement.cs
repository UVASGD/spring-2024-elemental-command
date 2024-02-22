using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingPowerLogicElement : MonoBehaviour
{

    private bool timerOn = true;
    private float timer = 5.0f;
    [SerializeField] private float timerDuration = 5.0f;

    [SerializeField] private LogicElement logic;

    [SerializeField] private MeshRenderer meshColor;

    public Color offColor;
    public Color onColor;

    private bool signal = false;

    // Start is called before the first frame update
    void Start()
    {
          meshColor.material.SetColor("_Color", offColor);
    }

    // Update is called once per frame
    void Update()
    {

        if (timerOn)
        {
            if (timer > 0)
            {

                timer -= Time.deltaTime;
            }

            else
            {
                // Debug.Log("Timer has switch states");
                timer = timerDuration;

                signal = !signal;

                if (signal)
                {

                    logic.SetActive();
                    meshColor.material.SetColor("_Color", onColor);

                }
                else
                {

                    logic.SetInactive();
                    meshColor.material.SetColor("_Color", offColor);
                }

            }
        } //timerOn
        
    } //Update


    public void ActivateIce()
    {
        timerOn = false;
    }
    public void EndIce()
    {
        timerOn = true;
    }

    public void ActivateElectricity()
    {
        timerDuration /= 2;
        timer /= 2; // in case the timer is still ongoing
    }

    public void EndElectricity()
    {
        timerDuration *= 2;
        timer *= 2;
    }
}
