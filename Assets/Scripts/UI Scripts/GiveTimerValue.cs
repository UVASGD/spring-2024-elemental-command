using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GiveTimerValue : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;

    TimerController timerController;
    // Start is called before the first frame update
    void Start()
    {
        timerController = GetComponent<TimerController>();
        float newTime = TimerData.timerData;
        timerController.currentTime = newTime;
        
    }

    // Update is called once per frame

}
