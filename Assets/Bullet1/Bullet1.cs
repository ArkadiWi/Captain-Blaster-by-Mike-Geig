using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    float speedY = 10f;

    GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        //odszukanie obiektu kontrolnego game manager
        gameManager = GameObject.FindObjectOfType<GameManager>();

        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(-16f, speedY);
        Destroy(this.gameObject,0.8f);
    }

    private void OnCollisionEnter2D(Collision2D other)        
    {
        Destroy(other.gameObject); //usuniêcie meteoru
        gameManager.AddScore(); //Inkrementacja liczby punktów
        Destroy(this.gameObject); // usuniêcie pocisku
    }    
}
