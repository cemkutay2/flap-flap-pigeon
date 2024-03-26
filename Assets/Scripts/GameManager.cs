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
        float unitsBetweenWalls = Random.Range(6f, 7f);
        float bottomWallPos = Random.Range(-5.5f, -0.5f);
        float topWallPos = bottomWallPos + unitsBetweenWalls;
        Instantiate(wallPrefab, new Vector2(10, bottomWallPos), wallPrefab.transform.rotation);
        Instantiate(wallPrefab, new Vector2(10, topWallPos), Quaternion.Euler(wallPrefab.transform.rotation.x, wallPrefab.transform.rotation.y, wallPrefab.transform.rotation.z + 180));
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
