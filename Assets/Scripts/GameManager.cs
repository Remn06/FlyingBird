using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject borderL, borderR, anchorL, anchorR;

    [SerializeField] private GameObject[] spikePrefabs;
    public GameObject currentSpike = null;

    void Start()
    {
        SetBordersPlace();
    }

    private void SetBordersPlace()
    {
        // Get left screen point in world's coords
        float leftX = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f)).x;

        // Setting borders to their positions

        borderL.transform.position = new Vector3(leftX, borderL.transform.position.y);
        borderR.transform.position = new Vector3(-leftX, borderR.transform.position.y);
    }

    public void SpawnSpikes(float playerDir)
    {
        GameObject spikesToSpawn = spikePrefabs[Random.Range(0, spikePrefabs.Length - 1)];
        if (playerDir < 0)
        {
            currentSpike = Instantiate(spikesToSpawn, anchorL.transform.position, Quaternion.Euler(0f, 0f, -90));
        }
        else
        {
            currentSpike = Instantiate(spikesToSpawn, anchorR.transform.position, Quaternion.Euler(0f, 0f, 90f));
        }
    }

}
