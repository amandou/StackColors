using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBlocks : MonoBehaviour
{
    public Transform stackPositionFinal;
    public Transform stackPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block")){
            
            Transform otherTransform = other.transform;
            other.enabled = false;
            
            stackPositionFinal.position += Vector3.up * (otherTransform.localScale.y);
            otherTransform.position = stackPositionFinal.position;
            otherTransform.parent = stackPosition;

        }


    }
}
