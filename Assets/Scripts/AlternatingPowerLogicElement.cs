using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingPowerLogicElement : MonoBehaviour
{

    [SerializeField] private float timer = 5.0f;

    [SerializeField] private LogicElement logic;

    [SerializeField] private MeshRenderer meshColor;

    public Color offColor;
    public Color OnColor;

    private bool signal = true;

    // Start is called before the first frame update
    void Start()
    {
          meshColor.material.SetColor("_Color", OnColor);
    }

    // Update is called once per frame
    void Update()
    {



        if (timer > 0){

            timer -= Time.deltaTime;
        }
        
        else {

            Debug.Log("Timer has switch states");
            timer = 5.0f;
            
            signal = !signal;

            if(signal){

                logic.SetActive();
                meshColor.material.SetColor("_Color", OnColor);

            } else {

                logic.SetInactive();
                meshColor.material.SetColor("_Color", offColor);
            }

        }


        
    }
}
