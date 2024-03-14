using UnityEngine;


public class Pause : MonoBehaviour
{

public GameObject pauseMenu;
public GameObject crosshair; //to turn off crosshair when paused
public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
    pauseMenu.SetActive(false);
    crosshair.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused){
                ResumeGame();
            } else {
                PauseGame();
            }

        }
        
    }

    public void PauseGame(){

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        crosshair.SetActive(false);


    }

    public void ResumeGame(){

        pauseMenu.SetActive(false);
        Debug.Log("game resumed");
        Time.timeScale = 1f;
        isPaused = false;
        crosshair.SetActive(true);

        
    }

    public void QuitApp(){
        Application.Quit();
        Debug.Log("Quitter!");
    }
}
