using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    private bool isGameOver = false;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (isGameOver && Input.anyKeyDown)
        {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score.ToString();
    }

    public void StopGame()
    {
        isGameOver = true;
        StopSpawn();
        StopScrolling();
        ShowGameOverPanel();
    }

    private void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    private void StopScrolling()
    {
        Scroll[] scrollingObjects = FindObjectsOfType<Scroll>();
        foreach (Scroll scrollingObject in scrollingObjects)
        {
            scrollingObject.StopScrolling();
        }
    }

    private void StopSpawn()
    {
        Spawner[] spawner = FindObjectsOfType<Spawner>();
        foreach (Spawner sp in spawner)
        {
            sp.StopSpawning();
        }
    }
}
