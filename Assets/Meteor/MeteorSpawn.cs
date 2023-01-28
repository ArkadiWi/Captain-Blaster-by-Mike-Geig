using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject meteorPrefab;
    public GameManager gameManager;    
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public float spawnXLimit = 6f;
     

    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }    


    void Spawn()
    {
        //utworzenie nowego meteoru w po³o¿eniu X
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        if (gameManager.playerScore > 60)
        {
            minSpawnDelay = 0.2f;
            maxSpawnDelay = 0.6f;
        }

        else if (gameManager.playerScore > 20)
        {
            minSpawnDelay = 0.5f;
            maxSpawnDelay = 1f;
        }
        
        else if (gameManager.playerScore > 10)
        {
            minSpawnDelay = 1f;
            maxSpawnDelay = 2f;
        }


        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));      
    }
}
