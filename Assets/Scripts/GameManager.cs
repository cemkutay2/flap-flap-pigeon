using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject wallPrefab;
    private Player player;
    private float score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public bool isGameActive;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    private float spawnRate = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        highScoreText.text = "HS: " + PlayerPrefs.GetInt("HighScore", 0);
    }
    void SpawnWall()
    {
        float unitsBetweenWalls = Random.Range(6f, 7f);
        float bottomWallPos = Random.Range(-5.5f, -0.5f);
        float topWallPos = bottomWallPos + unitsBetweenWalls;
        Instantiate(wallPrefab, new Vector2(10, bottomWallPos), wallPrefab.transform.rotation);
        Instantiate(wallPrefab, new Vector2(10, topWallPos), Quaternion.Euler(wallPrefab.transform.rotation.x, wallPrefab.transform.rotation.y, wallPrefab.transform.rotation.z + 180));
        StartCoroutine("SpawnAfterSecs");
    }
    public void GameOver()
    {
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
        }
        isGameActive = false;
        gameOverScreen.gameObject.SetActive(true);
        player.playerRb.simulated = false;
    }
    public void StartGame()
    {
        isGameActive = true;
        player.playerRb.simulated = true;
        SpawnWall();
        startScreen.SetActive(false);

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator SpawnAfterSecs()
    {
        yield return new WaitForSeconds(spawnRate);
        if (isGameActive)
            SpawnWall();
    }
    public void AddScore()
    {
        score += 0.5f;
        scoreText.text = $"{score:N0}";
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            highScoreText.text = $"HS: {score:N0}";
        }
    }
    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        highScoreText.text = "HS: 0";
    }
}
