using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{
    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameoverScreen;

    [ContextMenu("Score +1")] public void Add1Score() { AddScore(1); }


    public void AddScore(int score = 1)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // GameObject.FindGameObjectWithTag("Player").gameObject.SetActive(true);
    }

    public void GameOver()
    {
        gameoverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
