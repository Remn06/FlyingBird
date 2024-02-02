using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] spikes;
    [SerializeField] private Player player;
    private float spawnedDir;
    private float previousY = 4.5f;

    void Start()
    {
        SpikePositionCalc();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void SpikePositionCalc()
    {
        for (int i = 0; i < spikes.Length; i++)
        {
            spikes[i].transform.position = new Vector3(spikes[i].transform.position.x, previousY - Random.Range(1.25f, 2.75f));
            previousY = spikes[i].transform.position.y;
        }
    }

    public void DestroySelf()
    {
        if (spawnedDir != player.moveStep)
        {
            if (spawnedDir < 0)
            {
                transform.position = new Vector3(transform.position.x - 2f * Time.deltaTime, 0f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + 2f * Time.deltaTime, 0f);
            }
            Destroy(gameObject);
        }
    }
}
