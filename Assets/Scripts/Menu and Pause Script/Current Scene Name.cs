using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneNameUI : MonoBehaviour
{
    public TextMeshProUGUI sceneNameObject; // Use TextMeshProUGUI instead of TextMeshPro

    void Start()
    {
        // Get the current scene name
        string sceneName = SceneManager.GetActiveScene().name;

        // Update the text element with the scene name
        if (sceneNameObject != null) 
        {
            sceneNameObject.text = sceneName;
        }
        else
        {
            Debug.LogError("SceneNameObject is not assigned in the inspector.");
        }
    }
}
