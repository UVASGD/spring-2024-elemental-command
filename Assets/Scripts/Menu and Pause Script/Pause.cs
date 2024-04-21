using System.Reflection;
//using UnityEditor.SearchService;
using UnityEngine;


public class Pause : MonoBehaviour
{

public GameObject pauseMenu;
public GameObject crosshair; //to turn off crosshair when paused
public GameObject timer;
public static bool isPaused = false;

public SceneReloader sceneReloader;
    // Start is called before the first frame update
    void Start()
    {
    pauseMenu.SetActive(false);
    crosshair.SetActive(true);
    sceneReloader = FindAnyObjectByType<SceneReloader>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !sceneReloader.sceneTransitioning)
        {
            if(isPaused){
                ResumeGame();
            } else {
                PauseGame();
            }

        }
        
    }

    public void PauseGame(){
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        timer.SetActive(false);
        crosshair.SetActive(false);


    }

    public void ResumeGame(){

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        if (MainMenu.speedrunMode == true){
            timer.SetActive(true);
        }
        isPaused = false;
        crosshair.SetActive(true);

        
    }

    public void QuitApp(){
        Application.Quit();
    }
}
