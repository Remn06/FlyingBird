using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveStep;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameManager gameManager;

    void Update()
    {
        Move();

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0) == true)
        {
            Fly();
        }
    }

    private void Move()
    {
        transform.position = new Vector3(transform.position.x + moveStep * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ReverseGoBorder")
        {
            moveStep *= -1;

            if (gameManager.currentSpike != null)
            {
                gameManager.currentSpike.GetComponent<Obstacle>().DestroySelf();
            }

            gameManager.SpawnSpikes(moveStep);
        }
        else if (collision.gameObject.tag == "Spike")
        {
            GameOver();
        }
    }

    private void Fly()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        GameOver();
    }

    private void GameOver()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
