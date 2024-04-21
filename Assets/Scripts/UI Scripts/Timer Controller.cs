using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimerController : MonoBehaviour
{


    public TextMeshProUGUI timerText;

    public float currentTime;

    void Start()
    {
        Debug.Log("Timer data = " + TimerData.timerData);
        if (MainMenu.speedrunMode == false){
            this.gameObject.SetActive(false);
        }

    if (SceneManager.GetActiveScene().buildIndex == 3){
        currentTime *= 100;
        int someInt = Mathf.RoundToInt(currentTime);
        timerText.text = someInt.ToString("0");
        TimerData.timerData = currentTime;
    } 
    }

    // Update is called once per frame
    void Update()
    {
            if (SceneManager.GetActiveScene().buildIndex != 3){
                 currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("0.00");
            TimerData.timerData = currentTime;
            }

    }
}
