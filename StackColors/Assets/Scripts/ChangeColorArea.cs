using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorArea : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public List<Material> listMaterials;
    
    private Material areaMaterial, playerMaterial;

    private void Start()
    {
        playerMaterial = player.GetComponent<Renderer>().sharedMaterial;
        areaMaterial = GetComponent<Renderer>().material;
        SetAreaColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMaterial.color = areaMaterial.color;            
            ChangeChildColor();
        }
    }

    private void SetAreaColor()
    {
        int index = Random.Range(0, listMaterials.Count);
        areaMaterial.color = listMaterials[index].color;
    }

    private void ChangeChildColor()
    {
        List<Renderer> children = new List<Renderer>(spawnPoint.GetComponentsInChildren<Renderer>());
        for (int i = 0; i < children.Count; i++)
        {
            Material childMaterial = children[i].GetComponent<Renderer>().material;
            childMaterial.color = playerMaterial.color;
        }
    }

}
