using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRainEffect : MonoBehaviour
{
    [SerializeField] AudioClip raindropSFX;
    [SerializeField] ParticleSystem rainParticles;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rainParticles.GetComponent<ParticleSystem>().Pause();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            rainParticles.GetComponent<ParticleSystem>().Play();
            PlayRainSFX();
        }
    }

    void OnTriggerExit(Collider other)
    {
        rainParticles.GetComponent<ParticleSystem>().Stop();
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
