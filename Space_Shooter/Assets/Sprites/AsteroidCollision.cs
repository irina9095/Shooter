using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border" || other.tag == "Asteroid")
        {
            return;
        }
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

        }
        else
        {
            GameController gameсontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            gameсontroller.IncreaseScore(1);
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    } 
}
