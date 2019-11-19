using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject MoneyText;

    public GameObject buttonStart;
    public GameObject Menu;

    public GameObject Ship;

    public GameObject ButtonHangar;
    public GameObject Hangar;

    public GameObject playerExplosion;
    public GameObject AsteroidEmmiter;

    public GameObject You_Win;

    public bool isGameStarted = false;

    private int Score;
    private int Money;
    public void Start()
    {
        //PlayerPrefs.SetInt("Money", 9999);
        Money = PlayerPrefs.GetInt("Money");
        MoneyText.GetComponent<UnityEngine.UI.Text>().text = "Money: " + PlayerPrefs.GetInt("Money") + "$";
        Menu.SetActive(true);//Активируем меню
        buttonStart.SetActive(true);
        ButtonHangar.SetActive(true);

        isGameStarted = false;
        Vector3 startPosition = new Vector3(0, 0, -2.2F);
        var This_Ship = Instantiate(Ship, startPosition, Quaternion.identity);//Ставим корабль на сцену

        buttonStart.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate//Считываем нажатие на Start
        {
            Score = 0; //Обнуляем счёт
            You_Win.SetActive(false);
            ScoreText.SetActive(true);
            MoneyText.SetActive(true);

            buttonStart.SetActive(false);
            ButtonHangar.SetActive(false);
            Menu.SetActive(false);//Скрываем меню
            Hangar.SetActive(false);

            isGameStarted = true;//Устанавливаем флаг запуска игры

            AsteroidEmmiter.GetComponent<AsteroidEmmiter>().enabled = true;
        });
        ButtonHangar.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate//Считываем нажатие на Hangar
        {
            ButtonHangar.SetActive(false);
            MoneyText.SetActive(true);
            Menu.SetActive(false);
            Hangar.SetActive(true);//Открываем магазин с кораблями
        });
    }
    public void IncreaseScore (int increment)//Увеличиваем счёт
    {
        Score += increment;
        ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: "+ Score;
    }

    public void IncreaseMoney (int increment)
    {
        Money = PlayerPrefs.GetInt("Money") + increment;
        PlayerPrefs.SetInt("Money", Money);
        MoneyText.GetComponent<UnityEngine.UI.Text>().text = "Money: " + PlayerPrefs.GetInt("Money")+"$";
    }
    public void New_Ship (GameObject new_ship)//Установка нового корабля
    {
            Destroy(GameObject.FindWithTag("Player"));
            Ship = new_ship;
            Instantiate(Ship, new Vector3(0, 0, -2.2F), Quaternion.identity);
    }

    public void New_Game ()
    {
        isGameStarted = false;
        Instantiate(playerExplosion, Ship.transform.position, Ship.transform.rotation);//"Взрываем" корабль
        Start();//Перезапускаем GameController
        buttonStart.GetComponentInChildren<UnityEngine.UI.Text>().text = "Restart";//Кнопку Start переименовываем в Restart
    }
}
