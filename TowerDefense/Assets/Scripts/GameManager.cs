using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int sceneIndex = 0;
    [SerializeField] GameObject gameOverPanel;


    private void Awake()
    {
        BaseController.OnGameOver += GameOver;
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Reload()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnDestroy()
    {
        BaseController.OnGameOver -= GameOver;
    }

}
