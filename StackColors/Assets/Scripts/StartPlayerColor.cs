using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayerColor : MonoBehaviour
{
    private Material playerMaterial;

    void Start()
    {
        playerMaterial = GetComponent<Renderer>().sharedMaterial;
        playerMaterial.color = Color.gray;
    }
}
