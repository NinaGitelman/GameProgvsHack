using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private float timeLimit = 60f;
    private float currTimer;

    public TextMeshProUGUI timerText;

//
    private int score = 0;
    public TextMeshProUGUI scoreText;
    private int totalCollectibles = 12;
//
    private bool gameEnded;


    void Start()
    {
        currTimer = 60f;
        gameEnded = false;
        UpdateScoreText(); //
    }


    // Update is called once per frame
    void Update()
    {
        if (!gameEnded)
        {
            currTimer -= Time.deltaTime;
            timerText.text = Mathf.CeilToInt(currTimer).ToString();

            if (currTimer <= 0)
            {
                GameOver();
            }
        }
    }

//
    public void CollectedItem()
    {
        score++;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text =  score+ "/12";
        if (score == totalCollectibles)
        {
            Won();
        }

    }
    private void Won()
    {
        SceneManager.LoadScene("WonGame"); 

    }
//
    public void GameOver()
    {
        gameEnded = true;
        SceneManager.LoadScene("GameOver"); 
    }
}
