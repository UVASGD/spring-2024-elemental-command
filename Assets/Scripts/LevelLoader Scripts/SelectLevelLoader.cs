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


    public bool sceneTransitioning = false;




    public void LoadSelectedLevel(int buildIndex)
    {
        StartCoroutine(LoadLevel(buildIndex));

    }

    IEnumerator LoadLevel(int buildIndex)
    {


        Debug.Log("restart process initiated");

        transition.SetTrigger("Start");

        sceneTransitioning = true;

        yield return new WaitForSeconds(transitionTime);

        sceneTransitioning = false;

        SceneManager.LoadScene(buildIndex);
    }
}

