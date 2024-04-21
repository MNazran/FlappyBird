using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController _PlayerController;
    public SpawnerController _SpawnerController;
    public GameObject _MainMenu;
    public GameObject _InGameUI;
    public GameObject _GameOverUI;

    public float _BestScore;
    public TextMeshProUGUI UI_BestScore;
    public TextMeshProUGUI UI_Score;

    public Sprite[] Medal;
    public Image UI_Medal;

    public UIController UI_Controller;

    public void StartGame()
    {
        UI_Controller.StartGame();
    }

    public void StartGameLogic()
    {
        _BestScore = PlayerPrefs.GetFloat("BestScore");

        _PlayerController.StartGame = true;
        _SpawnerController.StartGame = true;
        _MainMenu.SetActive(false);
        _InGameUI.SetActive(true);
    }

    public void SetHighScore(float score)
    {
        if(score > _BestScore)
        {
            PlayerPrefs.SetFloat("BestScore", score);
            _BestScore = score;
        }

        UI_BestScore.text = _BestScore.ToString();
        UI_Score.text = score.ToString();

        if(score < 5)
        {
            UI_Medal.sprite = Medal[0];
        }
        else if(score >= 5 && score < 10)
        {
            UI_Medal.sprite = Medal[1];
        }
        else if(score >= 10)
        {
            UI_Medal.sprite = Medal[2];
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _GameOverUI.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }

        //android back button
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
