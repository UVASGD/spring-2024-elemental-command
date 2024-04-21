using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    private ElementManager em;

    private bool movingUp = true; // WWise: flag to indicate the direction of movement
    private float timer = 0.0f;

    void Start()
    {
        em = FindObjectOfType<ElementManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (em.state != ElementManager.Element.Ice)
        {
            // Check if the platform has reached its destination
            if (movingUp && transform.position == pointB.position)
            {
                movingUp = false; // Change the direction of movement
                // Wwise event for platform moving down
                AkSoundEngine.PostEvent("Play_PlatformMoveUp", gameObject);
            }
            else if (!movingUp && transform.position == pointA.position)
            {
                movingUp = true; // Change the direction of movement
                // Wwise event for platform moving up
                AkSoundEngine.PostEvent("Play_PlatformMoveUp", gameObject);
            }
            

            timer += Time.deltaTime;
            
            transform.position = Vector3.Lerp(pointA.position, pointB.position, (Mathf.Sin(timer) + 1) / 2);
        }
        
    }
    
}
