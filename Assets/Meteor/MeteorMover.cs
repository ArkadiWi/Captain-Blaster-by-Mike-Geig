using UnityEngine;

public class MeteorMover : MonoBehaviour
{   

    Rigidbody2D rigidBody;
    GameManager gameManager;
    float minVolocity = -2f;
    float maxVelocity = -3f;


    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rigidBody = GetComponent<Rigidbody2D>();
        if (gameManager.playerScore > 40)
        {
            minVolocity = -4;
            maxVelocity = -6;
        }
        else if (gameManager.playerScore > 20)
        {
            minVolocity = -3;
            maxVelocity = -4;
        }


        rigidBody.velocity = new Vector2(0, Random.Range(minVolocity, maxVelocity));
    }    
}
