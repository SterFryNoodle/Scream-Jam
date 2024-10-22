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
    bool isSprinting;
    void Start()
    {
        playerSpeed = baseSpeed;
    }
    
    void Update()
    {
        MovementInput();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            SetPlayerSpeed();
        }
        else
        {
            isSprinting = false;
            SetPlayerSpeed();
        }
    }

    void MovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        transform.Translate(horizontalInput, 0, verticalInput);
    }

    void SetPlayerSpeed()
    {
        if (isSprinting)
        {
            playerSpeed = sprintSpeed;
        }
        else
        {
            playerSpeed = baseSpeed;
        }
    }
}
