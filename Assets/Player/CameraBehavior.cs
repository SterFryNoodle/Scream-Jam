using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;  // How sensitive the mouse is
    [SerializeField] Transform playerBody;  // Reference to the player's body
    [SerializeField] float smoothTime = 0.1f;  // Time to smooth the rotation

    float xRotation = 0f;  // To store the vertical rotation
    float yRotation = 0f; // To store the horizontal rotation
    float yRotationVelocity;  // Velocity of smooth rotation for each axis

    void Start()
    {        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculate the vertical rotation (up and down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Clamp the rotation to prevent flipping over

        // Smooth rotation along the Y axes
        yRotation += mouseX;
        float smoothedYRotation = Mathf.SmoothDampAngle(playerBody.eulerAngles.y, yRotation, ref yRotationVelocity, smoothTime);   

        // Apply the rotations
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // Up/down rotation for the camera
        playerBody.rotation = Quaternion.Euler(0f, smoothedYRotation, 0f);  // Left/right rotation for the player body
    }
}
