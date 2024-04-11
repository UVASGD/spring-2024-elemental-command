using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public NextLevelLoader levelLoader;

    public SelectLevelLoader levelSelector;

   void Start()
{
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    levelLoader = FindObjectOfType<NextLevelLoader>();
    levelSelector = FindObjectOfType<SelectLevelLoader>();
}

    public void GoToNextScene(){
        Debug.Log("Went to next level");
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
