using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmmiter : MonoBehaviour
{
    public float minDelay;
    public float maxDelay;

    public GameObject asteroid_1, asteroid_2, asteroid_3;//определяем шаблоны астероидов
    private float AsteroidCount = 1;//Устанавливаем начальное значение
    private float nextSpawn;//время запуска нового астероида

    void Update()
    {
        bool isGameStarted = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().isGameStarted;//Проверка запуска игры

        if (!isGameStarted)
        {
            AsteroidCount = 1;//Если игра закончена/не запущена возвращаем количество астероидов в начальное значение
            return;
        }

        else if (Time.time > nextSpawn )
        {
            float maxAsteroid = Random.Range(1, AsteroidCount);//Выбираем случайное количество астероидов, которые появятся на сцене
            for (int i = 0; i < maxAsteroid; i++)
            {
                nextSpawn = Time.time + Random.Range(minDelay, maxDelay);//Случайно генерируем время до следующей генерации в заданных пределах

                float randomXPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
                float randomZPosition = transform.position.z + Random.Range(0, 5);

                Vector3 startPosition = new Vector3(//передаем сгенерированное случайное положение
                    randomXPosition,
                    transform.position.y,
                    randomZPosition
                    );

                GameObject asteroid = asteroid_1;//объект астероида по умолчанию

                switch (Random.Range(0, 3))//случайным образом выбираем астероид
                {
                    case 1:
                        asteroid = asteroid_2;
                        break;
                    case 2:
                        asteroid = asteroid_3;
                        break;
                    default:
                        break;
                }

                Instantiate(asteroid, startPosition, Quaternion.identity);//Генерируем астероид на сцене
            }
            AsteroidCount += 0.03f;//Увеличиваем максимальное количество
        }
    }
}
