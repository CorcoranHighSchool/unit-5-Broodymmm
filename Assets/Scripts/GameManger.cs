using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public Button restartButton;
    public TextMeshProUGUI gameOverText;

    private int score;

    public TextMeshProUGUI scoreText;

    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    private bool isGameActive = true;

    void Start()
    {
        restartButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
