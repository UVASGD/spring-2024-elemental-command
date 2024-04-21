using UnityEngine;
using AK.Wwise;

public class MusicController : MonoBehaviour
{
    public AK.Wwise.Event startEvent;

    void Start()
    {
        // Trigger the start event when the level loads
        startEvent.Post(gameObject);
    }

    void OnDestroy()
    {
        // Stop the music when the level is destroyed (when transitioning to the next level)
        AkSoundEngine.StopAll(gameObject);
    }
}
