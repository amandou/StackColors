using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBlocks : MonoBehaviour
{
    public Transform stackPositionFinal;
    public Transform stackPosition;
    public float lerpSpeed = 3.0f;

    public GameObject player;
    private Camera mainCamera;
    private Material playerMaterial;
    private void Start()
    {
        mainCamera = Camera.main;
        playerMaterial = player.GetComponent<Renderer>().sharedMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Add the right color to the stack
        Material blockMaterial = other.GetComponent<Renderer>().material;
        if (other.CompareTag("Block") && playerMaterial.color == blockMaterial.color 
            || playerMaterial.color == Color.gray)
        {
            
            Transform otherTransform = other.transform;
            other.enabled = false;
            
            stackPositionFinal.position += Vector3.up * (otherTransform.localScale.y);
            otherTransform.position = stackPositionFinal.position;
            otherTransform.parent = stackPosition;

            MoveCameraBehind();
        }
    }

    private void MoveCameraBehind()
    {
        float offset = mainCamera.GetComponent<FollowPlayer>().offsetPosition;
        Debug.Log(offset);

        Vector3 startPosition = new Vector3(mainCamera.transform.position.x,
                                            mainCamera.transform.position.y,
                                            mainCamera.transform.position.z);

        Vector3 newPosition = new Vector3(mainCamera.transform.position.x,
                                            mainCamera.transform.position.y + 0.1f,
                                            mainCamera.transform.position.z - 0.1f);
        Vector3 velocity = Vector3.zero;
        Vector3 interpolatedPosition =  Vector3.SmoothDamp(startPosition, newPosition, ref velocity, lerpSpeed);
        mainCamera.transform.position = interpolatedPosition;
    }
}
