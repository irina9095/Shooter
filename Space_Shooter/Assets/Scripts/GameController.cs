using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ScoreText;
    public GameObject buttonStart;
    public GameObject Menu;

    public bool isGameStarted = false;

    private int Score = 0;

    private void Start()
    {
        buttonStart.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate
        {
            buttonStart.SetActive(false);
            Menu.SetActive(false);
            ScoreText.SetActive(true);
            isGameStarted = true;
        });
    }
    public void IncreaseScore (int increment)
    {
        Score += increment;
        ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: "+ Score;
    }
}
