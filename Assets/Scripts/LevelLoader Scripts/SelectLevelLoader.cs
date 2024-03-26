using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelLoader : MonoBehaviour
{
    [SerializeField] public int buildIndex;

    public Animator transition;

    public float transitionTime;

    public Pause pause;

    void Start()
    {
        pause = FindObjectOfType<Pause>();
    }



    public void LoadSelectedLevel(int buildIndex)
    {
        StartCoroutine(LoadLevel(buildIndex));

    }

    IEnumerator LoadLevel(int buildIndex)
    {

        if (pause != null)
        {
            pause.ResumeGame();
        }

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);


        SceneManager.LoadScene(buildIndex);
    }
}

