using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obstacles;

    public void SpawnObstacles(float sideToSpawn)
    {
        if (sideToSpawn > 0)
        {
            Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)], new Vector2(2.4f, Random.Range(-1f, 1f)), Quaternion.Euler(0, 0, 90));
        }
        else
        {
            Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)], new Vector2(-2.4f, Random.Range(-1f, 1f)), Quaternion.Euler(0, 0, -90));
        }
    }
}
