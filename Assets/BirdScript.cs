using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapstrength;
    public bool birdIsAlive = true;
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.linearVelocity =  Vector2.up * flapstrength;
        }
        // Check if bird falls below y = -14
        if (transform.position.y < -14 && birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        Time.timeScale = 0;
    }
}
