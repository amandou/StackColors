using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> blocks;
    public int blocksSize = 12;

    private bool isSpawning;
    int minBlocks = 3;
    float decayRate = 0.05f;
    float chanceToSpawn = 1f;
    float distance = 20;

    void Start()
    {
        StartCoroutine(StartSpawning());
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
        distance += player.transform.position.x + 30;
        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
    }
    
    IEnumerator StartSpawning()
    {
        SpawnBlocks();
        float timeRespawn = Random.Range(1, 3);

        yield return new WaitForSeconds(timeRespawn);
    }
    
    void StopSpawning()
    {
        isSpawning = false;
        minBlocks = 3;
        decayRate = 0.05f;
        chanceToSpawn = 1f;
        
        while (!isSpawning)
        {
            float randomDraw = Random.Range(0, 1);
            if (randomDraw < chanceToSpawn)
            {
                distance += 12;
                transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
                chanceToSpawn -= decayRate;
            }
            else
            {
                StartSpawning();
            }
            
        }
    }
     
}
