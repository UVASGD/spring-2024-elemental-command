using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{


    public TextMeshProUGUI timerText;

    public float currentTime;

    void Start()
    {
        if (MainMenu.speedrunMode == false){
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("0.00");
        TimerData.timerData = currentTime;
    }
}
