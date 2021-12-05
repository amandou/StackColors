using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    //public GameObject playerBase;
    public GameObject player;

    private Material blockMaterial, baseMaterial, playerMaterial;

    private void Start()
    {
       playerMaterial = player.GetComponent<Renderer>().sharedMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {

        /*if (other.gameObject.CompareTag("Player") && (playerBase.GetComponent<Renderer>().material.name == "BasicPlayerMaterial"))
        {
            playerMaterial = blockMaterial;
            baseMaterial = blockMaterial;
        }(playerBase.GetComponent<Renderer>().material.name == blockMaterial.name)*/
        if (other.gameObject.CompareTag("Player") && playerMaterial.color == Color.gray)
        {
            blockMaterial = GetComponent<Renderer>().material;
            playerMaterial.color = blockMaterial.color;
        }
    }

    //Função de empilhar os blocos


}
