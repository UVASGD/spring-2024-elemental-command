using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelLoader levelLoader;

   void Start()
{
    levelLoader = FindObjectOfType<LevelLoader>();
}

    public void GoToNextScene(){
        levelLoader.LoadNextLevel();
    }

    public void QuitApp(){
        Application.Quit();
    }

}
