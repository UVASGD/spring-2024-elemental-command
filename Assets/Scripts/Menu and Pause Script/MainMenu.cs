using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public NextLevelLoader levelLoader;

    public SelectLevelLoader levelSelector;

   void Start()
{
    levelLoader = FindObjectOfType<NextLevelLoader>();
    levelSelector = FindObjectOfType<SelectLevelLoader>();
}

    public void GoToNextScene(){
        levelLoader.LoadNextLevel();
    }

    public void QuitApp(){
        Application.Quit();
    }

    public void GoToLevelSelect()
    {
        levelSelector.LoadSelectedLevel(3);
    }

}
