using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float offsetPosition;
    public GameObject spawnPoint;

    void LateUpdate()
    {
        List<Renderer> blocksStack = new List<Renderer>(spawnPoint.GetComponentsInChildren<Renderer>());

        if (target.position.x > transform.position.x)
        {
            Vector3 newPosition = new Vector3(target.position.x + offsetPosition,
                                                transform.position.y,
                                                transform.position.z);
            transform.position = newPosition;
            
            
        }
    }
}