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
        Debug.Log("Remember to put me in restart buttons and main menu buttons!");
        Debug.Log("Drag me into the OnClick() in the respective buttons, and in the int field, put what build index you want to go to");
        Debug.Log("0 for mainmenu and x for Level x");
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

        Debug.Log("process initiated");

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);


        SceneManager.LoadScene(buildIndex);
    }
}

