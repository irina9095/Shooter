using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Ship : MonoBehaviour
{
    public int Price;
    public string Ship_Number;

    public GameObject Ship_on_Sale;
    public GameObject button;
    public GameController gameсontroller;
    public GameObject MoneyText;
    public GameObject PriceText;

    public void Start()
    {
            if (PlayerPrefs.GetString(Ship_Number) == "Buied")
            {
                PriceText.GetComponent<UnityEngine.UI.Text>().text = " ";
            }
        button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate
        {
            
            int Money = PlayerPrefs.GetInt("Money");
            if (PlayerPrefs.GetString(Ship_Number)=="Buied")
            {
                gameсontroller.New_Ship(Ship_on_Sale);
            }
           else if (Money >= Price)
            {
                Money = Money - Price;
                PlayerPrefs.SetInt("Money", Money);
                PlayerPrefs.SetString(Ship_Number, "Buied");
                MoneyText.GetComponent<UnityEngine.UI.Text>().text = "Money: " + PlayerPrefs.GetInt("Money") + "$";
                gameсontroller.New_Ship(Ship_on_Sale);
                PriceText.GetComponent<UnityEngine.UI.Text>().text = " ";
            }
        });
    }
}
