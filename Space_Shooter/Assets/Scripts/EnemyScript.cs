using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{

    public float speed;
    public float tilt;

    Boundary boundary;
    public GameObject lazerShot;
    public GameObject lazerGun;
    public GameObject explosion;
    public GameObject mini_explosion;

    public float shotDelay;
    private float nextShoot;//время следующего выстрела
    private float Count_Shoot;
    private bool is_right = false;
    Vector3 offset;
    bool isGameStarted;

    void Update()
    {
        isGameStarted = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().isGameStarted;
        bool CanShoot = Time.time > nextShoot;

        if (!isGameStarted)
        {
            return;
        }
        else if (CanShoot)
        {
            nextShoot = Time.time + shotDelay;
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        GameController gameсontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();//Определяем GameController

            if (other.tag == "PlayerShoot")
            {
                Count_Shoot += 1;
                Instantiate(mini_explosion, transform.position, transform.rotation);
                Destroy(other.gameObject);//Уничтожаем второй объект
                if (Count_Shoot == 5)
            {
                gameсontroller.IncreaseMoney(50);
                gameсontroller.IncreaseScore(100);

                isGameStarted = false;

                Instantiate(explosion, transform.position, transform.rotation);//"Взрываем" вражеский корабль
                Destroy(GameObject.FindWithTag("Enemy"));//Уничтожаем объект врага
                Destroy(GameObject.FindWithTag("Player"));

                gameсontroller.Start();//Перезапускаем GameController
                gameсontroller.You_Win.SetActive(true);
                gameсontroller.buttonStart.GetComponentInChildren<UnityEngine.UI.Text>().text = "Restart";//Кнопку Start переименовываем в Restart
            }
            }
            else if (other.tag == "Player")
            {
                gameсontroller.New_Game();
            Instantiate(explosion, transform.position, transform.rotation);//"Взрываем" вражеский корабль
            Destroy(gameObject);//Уничтожаем объект врага
            Destroy(other.gameObject);//Уничтожаем второй объект
        }


    }

    void FixedUpdate()
    {
        GameController gameсontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();//Определяем GameController
        Rigidbody enemy = GetComponent<Rigidbody>();

        float offset_x = Random.Range(1f, 5f);
        float offset_z = Random.Range(1f, 5f);

        if (enemy.transform.position.x >= 3F)
            is_right = true;
        else if (enemy.transform.position.x <= -3F)
            is_right = false;

        if (is_right)
        {
            offset_x = -offset_x;
            offset = new Vector3(enemy.transform.position.x + offset_x, enemy.position.y, enemy.transform.position.z - offset_z);
            transform.position = Vector3.MoveTowards(transform.position, offset, 1f * Time.deltaTime);
        }
        else {
            
            offset = new Vector3(enemy.transform.position.x + offset_x, enemy.position.y, enemy.transform.position.z - offset_z);
            transform.position = Vector3.MoveTowards(transform.position, offset, 1f * Time.deltaTime);
        }
        if (enemy.transform.position.z < -8F) {
            Destroy(GameObject.FindWithTag("Enemy"));
            Destroy(GameObject.FindWithTag("Player"));
            gameсontroller.New_Game();
        }
    }
}
