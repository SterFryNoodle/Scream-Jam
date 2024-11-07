using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRainEffect : MonoBehaviour
{
    [SerializeField] AudioClip raindropSFX;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameObject.GetComponent<ParticleSystem>().Pause();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<ParticleSystem>().Play();
            PlayRainSFX();
        }
    }

    void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<ParticleSystem>().Stop();
        audioSource.Stop();
    }

    void PlayRainSFX()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = raindropSFX;
            audioSource.Play();
        }
    }
}
