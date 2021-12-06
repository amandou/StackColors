using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject player;

    private Material blockMaterial, playerMaterial;

    private void Start()
    {
       playerMaterial = player.GetComponent<Renderer>().sharedMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && playerMaterial.color == Color.gray)
        {
            blockMaterial = GetComponent<Renderer>().material;
            playerMaterial.color = blockMaterial.color;
        }
    }




}
