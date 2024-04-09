using UnityEngine;

public class ObjectDispenser : MonoBehaviour, ILogicReceiver
{
    public GameObject objectToDispense; // The object prefab to spawn
    public Transform spawnPoint; // The position where the object will be spawned

    [SerializeField] LogicElement logicElement;

    private GameObject lastSpawnedObject; // Track the last spawned object

    public void DispenseObject()
    {
        if (objectToDispense != null && spawnPoint != null)
        {
            // Instantiate the object and keep track of it
            lastSpawnedObject = Instantiate(objectToDispense, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Object or spawn point not assigned.");
        }
    }

    // Function to despawn the last spawned object
    public void DespawnLastObject()
    {
        if (lastSpawnedObject != null)
        {
            Destroy(lastSpawnedObject);
        }
    }

    public void UpdateLogic()
    {
        if (logicElement.GetCondition())
        {
            // If condition is met, despawn the last object (if any) and then spawn a new one
            DespawnLastObject();
            DispenseObject();
        }
    }
}