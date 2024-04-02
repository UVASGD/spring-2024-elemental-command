using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour, ILogicReceiver
{

    private bool readyForNextLevel = false;

    public Animator transition;

    public float transitionTime;

    [SerializeField] LogicElement logicElement;

    void Start()
    {
        
        readyForNextLevel = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(readyForNextLevel)
        {
            LoadNextLevel();
        }

        
        
    }

    public void UpdateLogic()
    {
        if (logicElement.GetCondition())
        {
            LoadNextLevel();
        }
    }


    public void LoadNextLevel()
    {
        //Loads next level in build index
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
