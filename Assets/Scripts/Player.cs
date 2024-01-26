using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject gameManagerObj;
    private GameManager gameManagerScript;

    private Rigidbody2D rb;
    private float moveDirection = 0.00375f;

    void Start()
    {
        // Application.targetFrameRate = Screen.currentResolution.refreshRateRatio;
        gameManagerScript = gameManagerObj.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    public void Fly()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 225, ForceMode2D.Force);
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x + moveDirection, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ReverseMovementBorder")
        {
            moveDirection *= -1;
            Debug.Log(moveDirection);
            gameManagerScript.SpawnObstacles(moveDirection);
        }
        else if (collision.tag == "Obstacle")
        {
            Death();
        }
    }

    private void Death()
    {
        SceneManager.LoadScene("GameScene");
    }
}
