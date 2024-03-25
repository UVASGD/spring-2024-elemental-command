using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelLoader : MonoBehaviour
{
    [SerializeField] public int buildIndex;

    public Animator transition;

    public float transitionTime;



    public void LoadSelectedLevel(int buildIndex)
    {
        StartCoroutine(LoadLevel(buildIndex));

    }

    IEnumerator LoadLevel(int buildIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(buildIndex);
    }
}

