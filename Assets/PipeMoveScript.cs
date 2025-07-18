using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float speed = 5; // Speed of the pipe movement
    public float deadZone = -45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject); // Destroy the pipe if it goes past the dead zone
        }
    }
}
