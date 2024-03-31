using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D playerRb;
    private GameManager gameManager;
    private float yRange = 5.7f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y) > yRange)
        {
            gameManager.GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.isGameActive)
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            gameManager.AddScore();
        }
        else
        {
            gameManager.GameOver();
        }
    }
}
