using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
            return;
        }
        else if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
