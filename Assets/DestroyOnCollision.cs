using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public float collisionSpeedThreshold = 5f; // Define the collision speed threshold here

    private ElementManager element;

    void Start()
    {
        element = FindObjectOfType<ElementManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.gameObject.CompareTag("Player") && element.state == ElementManager.Element.Earth)
        {
            // Check if the collision velocity magnitude is greater than the threshold
            if (collision.relativeVelocity.magnitude >= collisionSpeedThreshold)
            {
                Destroy(gameObject); // Destroy the game object
            }
        }
    }
}
