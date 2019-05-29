using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject buttonStart;
    public GameObject Menu;
    public GameObject Ship;
    public GameObject ButtonHangar;
    public GameObject Hangar;

    public bool isGameStarted = false;

    private int Score;

    public void Start()
    {
        Menu.SetActive(true);//Активируем меню
        buttonStart.SetActive(true);
        ButtonHangar.SetActive(true);

        isGameStarted = false;
        Vector3 startPosition = new Vector3(0, 1, -3);
        var This_Ship = Instantiate(Ship, startPosition, Quaternion.identity);//Ставим корабль на сцену

        buttonStart.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate//Считываем нажатие на Start
        {
            Score = 0; //Обнуляем счёт
            ScoreText.SetActive(true);
            buttonStart.SetActive(false);
            ButtonHangar.SetActive(false);
            Menu.SetActive(false);//Скрываем меню
            Hangar.SetActive(false);
            isGameStarted = true;//Устанавливаем флаг запуска игры
        });
        ButtonHangar.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate//Считываем нажатие на Hangar
        {
            ButtonHangar.SetActive(false);
            Menu.SetActive(false);
            Hangar.SetActive(true);//Открываем магазин с кораблями
        });
    }
    public void IncreaseScore (int increment)//Увеличиваем счёт
    {
        Score += increment;
        ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: "+ Score;
    }

    public void New_Ship (GameObject new_ship, int price)//Покупка нового корабля
    {
        if (Score >= price)
        {
            Destroy(GameObject.FindWithTag("Player"));
            Ship = new_ship;
            Instantiate(Ship, new Vector3(0, 1, -3), Quaternion.identity);
        }
    }
}
