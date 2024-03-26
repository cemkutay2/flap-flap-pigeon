using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallLeft : MonoBehaviour
{
    public float speed = 5f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
