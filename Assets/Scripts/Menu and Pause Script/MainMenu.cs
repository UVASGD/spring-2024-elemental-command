using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public NextLevelLoader levelLoader;

    public SelectLevelLoader levelSelector;

    public static bool speedrunMode;

   void Start()
{
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    levelLoader = FindObjectOfType<NextLevelLoader>();
    levelSelector = FindObjectOfType<SelectLevelLoader>();
    speedrunMode = false;
    TimerData.timerData = 0;
}

    public void GoToNextSceneCasual(){
        Debug.Log("Went to next level");
        speedrunMode = false;
        levelLoader.LoadNextLevel();
    }

        public void GoToNextSceneSpeedrun(){
        Debug.Log("Went to next level");
        speedrunMode = true;
        levelLoader.LoadNextLevel();
    }

    public void QuitApp(){
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void GoToLevelSelect()
    {
        levelSelector.LoadSelectedLevel(3);
    }

}
