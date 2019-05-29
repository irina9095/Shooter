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

        if (other.tag == "Border" || other.tag == "Asteroid")
        {
            return;//Ничего не делаем, если это другой астероид или границы
        }
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);//"Взрываем" корабль
            gameсontroller.Start();//Перезапускаем GameController
            gameсontroller.buttonStart.GetComponentInChildren<UnityEngine.UI.Text>().text = "Restart";//Кнопку Start переименовываем в Restart
        }
        else
        {
            gameсontroller.IncreaseScore(1);//Если астероид столкнулся с выстрелом, увеличиваем количество очков
        }

        Instantiate(explosion, transform.position, transform.rotation);//"Взрываем" астероид
        Destroy(gameObject);//Уничтожаем объект астероида
        Destroy(other.gameObject);//Уничтожаем выстрел
    } 
}
