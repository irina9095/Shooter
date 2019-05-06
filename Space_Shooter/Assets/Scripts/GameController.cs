using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject buttonStart;
    public GameObject Menu;
    public GameObject Ship;

    public bool isGameStarted = false;

    private int Score = 0;

    public void Start()
    {
        buttonStart.SetActive(true);
        Menu.SetActive(true);
        isGameStarted = false;
        Vector3 startPosition = new Vector3(0, 1, -3);
        Instantiate(Ship, startPosition, Quaternion.identity);

        buttonStart.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate
        {
            Score = 0;
            ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + Score;
            buttonStart.SetActive(false);
            Menu.SetActive(false);
            isGameStarted = true;
        });
    }
    public void IncreaseScore (int increment)
    {
        Score += increment;
        ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: "+ Score;
    }
}
