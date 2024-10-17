using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float baseSpeed = 4f;
    [SerializeField] float sprintSpeed = 8f;
    float playerSpeed;
    float horizontalInput;
    float verticalInput;

    void Start()
    {
        playerSpeed = baseSpeed;
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        transform.Translate(horizontalInput, 0, verticalInput);

        bool isSprinting = Input.GetKey(KeyCode.LeftShift); //Set bool to determine what mode player speed should be set to based on input.

        if(isSprinting)
        {
            playerSpeed = sprintSpeed;
        }
    }
}
