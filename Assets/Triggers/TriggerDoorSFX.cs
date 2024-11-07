using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorSFX : MonoBehaviour
{
    [SerializeField] AudioClip doorSqueak;

    AudioSource audioSource;
    bool isTriggered = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isTriggered)
        {
            audioSource.clip = doorSqueak;
            audioSource.Play();
            isTriggered = true;
        }        
    }
}
