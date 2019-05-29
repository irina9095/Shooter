using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Ship : MonoBehaviour
{
    public int Price;
    public GameObject Ship_on_Sale;
    public GameObject button;
    public GameController gameсontroller;

    public void Start()
    {
        button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate
        {
            gameсontroller.New_Ship(Ship_on_Sale, Price);
        });
    }
}
