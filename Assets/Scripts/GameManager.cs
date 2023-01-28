using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI; // obs³uga interfejsu

public class GameManager : MonoBehaviour
{    
    public Text gameOverText;

    public Text scoreText;
    public int playerScore = 0;

    public Text blasterTime;
    public bool blasterPossibility = false;
    public float timeToBlaster = 10;


    public void AddScore()
    {
        playerScore++;
        //konwersja wyniku na string
        scoreText.text = playerScore.ToString();
    }

    public void PlayerDied()
    {
        //gameOverText.enabled = true;
        gameOverText.gameObject.SetActive(true);
        //zatrzymanie gry
        Time.timeScale = 0;
    }

    private void Update()
    {
       if (playerScore >= 2)
        {
           Blaster();
        }
    }


    public void Blaster()
    {
        blasterTime.text = ("Time To Blaster: " + (int)timeToBlaster);
        timeToBlaster -= Time.deltaTime;
        if (timeToBlaster <= 0)
        {
            timeToBlaster = 0;
            blasterPossibility = true;
        }
    }
}
