using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour {

    private GameeController gameeController1;
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;


    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject!=null)
        {
            gameeController1 = gameControllerObject.GetComponent<GameeController>();
        }
        if (gameControllerObject = null)
        {
            Debug.Log("Cannot find 'GameeController' script ");
        }
    }




    void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (explosion != null)

        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
            
        if (other.tag == "Player")
             {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameeController1.GameOver();
             }

       gameeController1.AddScore(scoreValue);

        Destroy(other.gameObject);
        Destroy(gameObject);
     
    }













}
