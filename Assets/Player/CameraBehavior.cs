using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100f;  // How sensitive the mouse is
    [SerializeField] Transform playerBody;  // Reference to the player's body
    [SerializeField] float smoothTime = 0.1f;  // Time to smooth the rotation

    private float xRotation = 0f;  // To store the vertical rotation
    private Vector2 currentRotation;  // Current smooth rotation values
    private Vector2 rotationVelocity;  // Velocity of smooth rotation for each axis

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

        // Smooth rotation along the X and Y axes
        Vector2 targetRotation = new Vector2(xRotation, transform.localEulerAngles.y + mouseX);
        currentRotation = Vector2.SmoothDamp(currentRotation, targetRotation, ref rotationVelocity, smoothTime);

        // Apply the rotations
        transform.localRotation = Quaternion.Euler(currentRotation.x, 0f, 0f);  // Up/down rotation for the camera
        playerBody.Rotate(Vector3.up * mouseX);  // Left/right rotation for the player body
    }
}
