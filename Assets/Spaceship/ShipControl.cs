using UnityEditor;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;
    public float speed = 50f;
    public float xLimit = 7f;
    public float reloadTime = 0.5f;

    private float _elapsedTime = 0f;
       
    
    void Update()
    {
        //wy³¹czenie kursora
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        //monitorowanie czasu dla wystrzelenia pocisku
        _elapsedTime += Time.deltaTime;

        //przesuwanie obiektu gracza w lewo i prawo
        float _xInput = Input.GetAxis("Mouse X");

        //przesuwanie do przodu i do ty³u
        float _yInput = Input.GetAxis("Mouse Y");        

        transform.Translate(_xInput * speed * Time.deltaTime, _yInput * speed * Time.deltaTime, 0f);

        // ograniczenie po³o¿enia statku na osi X i Y
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        position.y = Mathf.Clamp(position.y, -5f, -2f);
        transform.position = position;

        //spacja powoduje wystrzelenie pocisku obecna konfiguracja okreœla
        //to "Jump", strza³ bêdzie mo¿liwy je¿eli od poprzedniego up³ynê³o wystarczaj¹co du¿o czasu.
        if (Input.GetButtonDown("Fire1") && _elapsedTime > reloadTime)
        {
            //utworzenie egzemplarza pocisku w odleg³ 1.2 od gracza
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0, 1.2f, 0);
            Instantiate (bulletPrefab, spawnPos, Quaternion.identity);

            //wyzerowanie licznika czasu od chwili strza³u
            _elapsedTime = 0f;
        }

        if (Input.GetButtonDown("Fire2") && gameManager.blasterPossibility == true)
        {
            Vector3 spawnPos1 = transform.position;
            Vector3 spawnPos2 = transform.position;
            Vector3 spawnPos3 = transform.position;
            Vector3 spawnPos4 = transform.position;
            spawnPos1 += new Vector3(0.6f, 1.2f, 0);
            spawnPos2 += new Vector3(0.3f, 1.2f, 0);
            spawnPos3 += new Vector3(-0.3f, 1.2f, 0);
            spawnPos4 += new Vector3(-0.6f, 1.2f, 0);

            Instantiate(bulletPrefab1, spawnPos1, Quaternion.identity);
            Instantiate(bulletPrefab2, spawnPos2, Quaternion.identity);
            Instantiate(bulletPrefab3, spawnPos3, Quaternion.identity);
            Instantiate(bulletPrefab4, spawnPos4, Quaternion.identity);

            //Instantiate(bulletPrefab, spawnPos2, Quaternion.Euler(0f, 0f, 45f));
            ////Instantiate(bulletPrefab, spawnPos3, Quaternion.identity);
            ////Instantiate(bulletPrefab, spawnPos3, bulletPrefab.transform.rotation = Quaternion.Euler(15f,10f,10f));
            //Instantiate(bulletPrefab, spawnPos3, transform.rotation = Quaternion.Euler(20f,20f,20f));



            gameManager.timeToBlaster = 10;
            gameManager.blasterPossibility = false;
        }



    }

    //je¿eli meteor uderzy³ w gracza
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        gameManager.PlayerDied();
    }

}
