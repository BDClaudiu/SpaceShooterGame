using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameeController : MonoBehaviour {

    public GameObject [] hazards;
    
    public int hazardCount;
    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int score;


    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;

    

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        UpdateScore();
      StartCoroutine(  SpawnWaves() );
    }


    private void Update()
    {
        if (restart)
        {

            if(Input.GetKeyDown(KeyCode.R))
               {
                 Application.LoadLevel(Application.loadedLevel);
               }
        }
    }





    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);


        while (true)
        {


            for (int i = 0; i < hazardCount; i++)
                
        { GameObject hazard = hazards[Random.Range(0,hazards.Length)];

              
                 
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);

              
            yield return new WaitForSeconds(spawnWait);
        }


      
            yield return new WaitForSeconds (waveWait);

            if (gameOver)
            {
                restartText.text = "PRESS 'R' FOR RESTART";
                restart = true;
                break;
            }


        }

    }


    

    public   void AddScore (int newScoreValue)
    {

        score += newScoreValue;
        UpdateScore();
    }
	
    void UpdateScore ()
    {

        scoreText.text = "Score: " + score;

    }


    public void GameOver()
    {
        gameOverText.text = "GAME OVER!!";
        gameOver = true;
    }





}
