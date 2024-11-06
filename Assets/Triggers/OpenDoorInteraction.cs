using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorInteraction : MonoBehaviour
{    
    [SerializeField] float rotationAngle = 30f;
    [SerializeField] float interactionRange = 1.5f;
    [SerializeField] AudioClip doorOpenSound;
    [SerializeField] AudioClip knobJiggleSound;
        
    bool isOpened = false;
    GameObject playerObject;
    AudioSource audioSource;

    void Start()
    {
        playerObject = FindObjectOfType<PlayerHealth>().gameObject;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distance = Vector3.Distance(playerObject.transform.position, transform.position);

        if (distance <= interactionRange)
        {            
            OpenDoorAction();
        }        
    }

    void OpenDoorAction()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpened && gameObject.tag != "Locked Door")
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotationAngle, transform.eulerAngles.z);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            PlayDoorOpenSFX();
            isOpened = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && gameObject.tag == "Locked Door")
        {
            PlayLockedDoorSFX();
        }
    }

    void PlayLockedDoorSFX()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = knobJiggleSound;
            audioSource.Play();
        }
    }

    void PlayDoorOpenSFX()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = doorOpenSound;
            audioSource.Play();
        }
    }
}
