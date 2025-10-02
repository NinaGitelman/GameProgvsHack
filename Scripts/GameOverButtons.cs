using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restart()
    {

        SceneManager.LoadScene("GameScene"); 

    }
    public void GoToMenu()
    {

        SceneManager.LoadScene("Menu"); 

    }
}
