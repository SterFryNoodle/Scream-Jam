using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorInteraction : MonoBehaviour
{    
    [SerializeField] float rotationAngle = 30f;
    [SerializeField] float interactionRange = 3f;

    bool inRange = false;
    bool isOpened = false;
    GameObject playerObject;

    void Start()
    {
        playerObject = FindObjectOfType<PlayerHealth>().gameObject;
    }

    void Update()
    {
        float distance = Vector3.Distance(playerObject.transform.position, transform.position);

        if (distance <= interactionRange)
        {
            inRange = true;
            OpenDoorAction();
        }
        else
        {
            inRange = false;
        }
    }

    void OpenDoorAction()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpened)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotationAngle, transform.eulerAngles.z);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            isOpened = true;
        }
    }
}
