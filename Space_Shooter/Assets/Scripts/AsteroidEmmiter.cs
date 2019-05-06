using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmmiter : MonoBehaviour
{
    public float minDelay;
    public float maxDelay;

    public GameObject asteroid;
    private float AsteroidCount = 1;
    private float nextSpawn;//время запуска нового астероида

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isGameStarted = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().isGameStarted;

        if (!isGameStarted)
        {
            AsteroidCount = 1;
            return;
        }

        else if (Time.time > nextSpawn )
        {
            float maxAsteroid = Random.Range(1, AsteroidCount);
            for (int i = 0; i < maxAsteroid; i++)
            {
                nextSpawn = Time.time + Random.Range(minDelay, maxDelay);

                float randomXPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                float randomZPosition = transform.position.z + Random.Range(0, 5);

                Vector3 startPosition = new Vector3(
                    randomXPosition,
                    transform.position.y,
                    randomZPosition
                    );
                Instantiate(asteroid, startPosition, Quaternion.identity);
            }
            AsteroidCount += 0.03f;
        }
    }
}
