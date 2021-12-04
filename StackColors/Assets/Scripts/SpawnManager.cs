 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public List<Vector3> spawnPositions;
    public List<GameObject> blocks;
    public int blocksSize = 12;

    [SerializeField]
    private float distanceBetweenPlayerSpawnManager;



    void Start()
    {
        SpawnBlocks();   
    }

    void Update()
    {
        float distanceBetweenPlayerSpawnManager = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(distanceBetweenPlayerSpawnManager);
        if (distanceBetweenPlayerSpawnManager < blocksSize)
        {
            UpdateSpawnPosition();
            SpawnBlocks();
        }

    }

    void SpawnBlocks()
    {
        int index = Random.Range(0, blocks.Count);
        Instantiate(blocks[index], GenerateSpawnPosition(), blocks[index].transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        int indexSpawnPosition = Random.Range(0, spawnPositions.Count);
        return spawnPositions[indexSpawnPosition];
    }

    private void UpdateSpawnPosition()
    {
        int xPosition = Random.Range(0, 5);
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            spawnPositions[i] = new Vector3(spawnPositions[i].x + (blocksSize + xPosition),
                                            spawnPositions[i].y,
                                            spawnPositions[i].z);
        }
        
    }




}
