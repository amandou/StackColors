using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;
    private float horizontalMovement;

    public float horizontalSpeed;
    public float verticalSpeed;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Movement();   
    }

    void GetInput()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    void Movement()
    {
        Vector3 direction = -transform.forward * horizontalMovement * horizontalSpeed + transform.right * verticalSpeed ;
        playerController.Move(direction * Time.deltaTime);
    }
}
