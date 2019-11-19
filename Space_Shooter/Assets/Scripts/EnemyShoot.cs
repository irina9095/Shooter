using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.back * speed;
    }
    public void OnTriggerEnter(Collider other)
    {
        GameController gameсontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();//Определяем GameController

        if (other.tag == "Player" || other.tag == "PlayerShoot")
        {
            if (other.tag == "Player") gameсontroller.New_Game();

            Destroy(gameObject); //Уничтожаем объект астероида
            Destroy(other.gameObject); //Уничтожаем выстрел
        }
        else
        {
            return;
        }
    }
    }
