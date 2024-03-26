using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject wallPrefab;
    private Player player;
    public bool isGameActive;
    public Button restartButton;
    private float spawnRate = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        StartGame();
    }
    void SpawnWall()
    {
        float unitsBetweenWalls = Random.Range(9f, 10.5f);
        float bottomWallPos = Random.Range(-7f, -2.5f);
        float topWallPos = bottomWallPos + unitsBetweenWalls;
        Instantiate(wallPrefab, new Vector2(10, bottomWallPos), wallPrefab.transform.rotation);
        Instantiate(wallPrefab, new Vector2(10, topWallPos), wallPrefab.transform.rotation);
        StartCoroutine("SpawnAfterSecs");
    }
    public void GameOver()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        player.playerRb.simulated = false;
    }
    public void StartGame()
    {
        isGameActive = true;
        SpawnWall();
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
}
