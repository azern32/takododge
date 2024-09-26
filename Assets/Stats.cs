using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;

    [ContextMenu("Score +1")]
    public void addScore(int score = 1)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }
}
