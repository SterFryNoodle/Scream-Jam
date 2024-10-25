using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPickupSound : MonoBehaviour
{
    [SerializeField] AudioClip pickupSFX;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.clip = pickupSFX;
            audioSource.Play();
        }        
    }
}
