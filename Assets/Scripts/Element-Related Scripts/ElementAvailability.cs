using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ElementAvailability : MonoBehaviour
{

[SerializeField] public bool Ice_Available;

[SerializeField] public bool Earth_Available;

[SerializeField] public bool Air_Available;

[SerializeField] public bool PlayerCanCancel;

public static int count = 0;

void Start(){
    NumberOfAvailableElements();

}
    public void NumberOfAvailableElements(){

        int counter = 0;

        if (Ice_Available)
            counter++;
        if (Earth_Available)
            counter++;
        if (Air_Available)
            counter++;

        count = counter;
    }

    public bool PlayerCanCancelState(){
        if (PlayerCanCancel){
            return true;
        } else {
            return false;
        }
    }
}
