using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public float collisionSpeedThreshold = 5f; // Define the collision speed threshold here

        private ElementManager em;

    void Start()
    {
        em = FindObjectOfType<ElementManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("impact was made");
        if (collision.gameObject.CompareTag("Player") && em.state == ElementManager.Element.Earth)
        {
            // Check if the collision velocity magnitude is greater than the threshold
            if (collision.relativeVelocity.magnitude >= collisionSpeedThreshold)
            {
                Destroy(gameObject); // Destroy the game object
            }
        }
    }
}
