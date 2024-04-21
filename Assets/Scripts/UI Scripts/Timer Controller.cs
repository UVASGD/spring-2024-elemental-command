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

    }

    // Update is called once per frame
    void Update()
    {
            if (SceneManager.GetActiveScene().buildIndex != 9){
                 currentTime += Time.deltaTime;
                timerText.text = currentTime.ToString("0.00");
                TimerData.timerData = currentTime;
            }

            if (SceneManager.GetActiveScene().buildIndex == 9){
                timerText.text = currentTime.ToString("0.00");
        
            }



    }
}
