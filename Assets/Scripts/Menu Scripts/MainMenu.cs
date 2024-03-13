using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

    public void GoToScene(string SceneName){
        SceneManager.LoadScene(SceneName);
    }

    public void QuitApp(){
        Application.Quit();
        Debug.Log("Quitter!");
    }

}
