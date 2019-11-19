using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;



    public void OnTriggerEnter(Collider other)
    {
        GameController gameсontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();//Определяем GameController

        if (other.tag == "Border" || other.tag == "Asteroid" || other.tag == "EnemyShoot" || other.tag == "Enemy")
        {
            return;
        }
        if(other.tag == "Player")
        {
            gameсontroller.New_Game();
        }
        else
        {
            gameсontroller.IncreaseScore(1);//Если астероид столкнулся с выстрелом, увеличиваем количество очков
            gameсontroller.IncreaseMoney(1);
        }

        Instantiate(explosion, transform.position, transform.rotation);//"Взрываем" астероид
        Destroy(gameObject);//Уничтожаем объект астероида
        Destroy(other.gameObject);//Уничтожаем выстрел
    } 
}
