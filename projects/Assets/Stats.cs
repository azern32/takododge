
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{
    public int playerScore = 0;
    public float fps;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI fpsText;
    public GameObject gameoverScreen;
    public GameObject pauseScreen;

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

    public void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
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

    void Update()
    {
        fps = Mathf.Round(1 / Time.unscaledDeltaTime);
        fpsText.text = fps.ToString();

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Escape))
        {
            if (!pauseScreen.activeSelf)
            {
                Pause();
            }
        }
    }


}
