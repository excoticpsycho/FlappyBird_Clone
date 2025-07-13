using UnityEngine;

public class PersistentAudio : MonoBehaviour
{
    void Awake()
    {
        // Ensure only one instance exists
        if (GameObject.FindGameObjectsWithTag("PersistentAudio").Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
