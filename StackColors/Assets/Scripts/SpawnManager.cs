using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> blocks;
    public int blocksSize = 12;

    private bool isSpawning = false;

    void Start()
    {
        SpawnBlocks();   
    }

    void Update()
    {/*
        float distanceBetweenPlayerSpawnManager = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log("distance "+distanceBetweenPlayerSpawnManager);
        if (distanceBetweenPlayerSpawnManager < blocksSize)
        {
            UpdateSpawnPosition();
            SpawnBlocks();
        }
        */
    }

    void SpawnBlocks()
    {
        int index = Random.Range(0, blocks.Count);
        int blocksQuantity = Random.Range(5, 10);

        for (int i = 0; i < blocksQuantity; i++)
        {
            Instantiate(blocks[index], transform.position, blocks[index].transform.rotation);
            transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
        }
    }

    void ProbabilityToSpawn()
    {

    }

}
