using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{


    public Animator transition;

    public bool sceneTransitioning;

    public float transitionTime;

    public Pause pause;

    void Start()
    {
        pause = FindObjectOfType<Pause>();
        sceneTransitioning = false;
    }



    public void LoadCurrentLevel()
    {
        //Loads next level in build index
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));

    }

    IEnumerator LoadLevel(int levelIndex)
    {

        if (pause != null)
        {
            pause.ResumeGame();
        }

        sceneTransitioning = true;

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        sceneTransitioning = false;

        SceneManager.LoadScene(levelIndex);
    }
}
