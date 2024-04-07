using UnityEngine;

public class ObjectDispenser : MonoBehaviour, ILogicReceiver
{
    public GameObject objectToDispense; // The object prefab to spawn
    public Transform spawnPoint; // The position where the object will be spawned

    [SerializeField] LogicElement logicElement;

    public void DispenseObject()
    {
        if (objectToDispense != null && spawnPoint != null)
        {
            Instantiate(objectToDispense, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Object or spawn point not assigned.");
        }
    }

     public void UpdateLogic()
    {
        if (logicElement.GetCondition())
        {
            DispenseObject();
        }
    }
}