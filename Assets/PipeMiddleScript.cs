using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public AudioSource scoreSound;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
            if (scoreSound != null)
            {
                scoreSound.Play();
            }
            else
            {
                Debug.LogWarning("Score sound not assigned in PipeMiddleScript.");
            }

        }
    }
}