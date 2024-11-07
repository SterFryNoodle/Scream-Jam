using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWhsiper : MonoBehaviour
{
    [SerializeField] AudioClip whisperClip;

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
            audioSource.clip = whisperClip;
            audioSource.Play();
            isTriggered = true;
        }
    }
}
