using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
   // public float spawnWait;
    public float startWait;
    public float waveWait;
    public float minutes;
    public float seconds;

    public Text scoreText;

    private float score;
    
    private bool gameOver;
    private bool restart;
   
    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnWaves());
    }
        void Update ()
    {
        minutes = Mathf.Floor(Time.timeSinceLevelLoad / 60);
        seconds =Mathf.Floor( Time.timeSinceLevelLoad % 60);
        if (minutes < 10)
        {
            if (seconds < 10)
                scoreText.text = "Score: 0" + minutes + ":0" + seconds;
            else
                scoreText.text = "Score: 0" + minutes + ":" + seconds;
        }
        if (minutes > 9) {
            if (seconds < 10)
                scoreText.text = "Score: " + minutes + ":0" + seconds;
            else
                scoreText.text = "Score: " + minutes + ":" + seconds;
        }
       // scoreText.text = "Score: " + minutes + ":" + seconds;
        if (restart)
            {
                    Application.LoadLevel(Application.loadedLevel);
            }
        }

    IEnumerator SpawnWaves()
    {
        
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            
            for (int i = 0; i < hazardCount; i++)
            {
               
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(Random.Range(0.5f,2f));  //sau spawnWait
                if (gameOver)
                {

                    //restartText.text = "Press 'R' for Restart";
                    restart = true;
                    break;
                }
            }
            yield return new WaitForSeconds(waveWait);
           
        }
    }
    public void GameOver()
    {
       // gameOverText.text = "Game Over!";
        gameOver = true;
    }
}