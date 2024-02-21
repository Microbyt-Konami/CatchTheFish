using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private GameObject gameOverPanel;
    [SerializeField] private bool isGameOver = false;

    public void StartGame()
    {
        isGameOver = false;
        FishSpawner.instance.GetFishes();
        FishSpawner.instance.StartSpawnFishes();
        GameObject.Find("Player").GetComponent<PlayerController>().IsMoving = true;
    }

    public void GameOver()
    {
        isGameOver = true;
        FishSpawner.instance.StopSpawnFishes();
        GameObject.Find("Player").GetComponent<PlayerController>().IsMoving = false;
        gameOverPanel.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    private void Awake()
    {
        instance = this;
        gameOverPanel = GameObject.Find("Game Over Panel");
        gameOverPanel.SetActive(false);
    }

    private void Start()
    {
        StartGame();
    }
}
