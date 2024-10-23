using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootsteps : MonoBehaviour
{
    [SerializeField] AudioClip footStepsClip;
    [SerializeField] float resetSoundDistance = 2f;

    AudioSource audioSource;
    float distanceTraveled = 0f;
    Vector3 lastPosition;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }
    void Update()
    {
        if (isMoving())
        {
            distanceTraveled += Vector3.Distance(transform.position, lastPosition);

            if (distanceTraveled > resetSoundDistance)
            {
                GetFootstepsAudio();
                distanceTraveled = 0f;
                lastPosition = transform.position;
            }
            
        }
    }
    void GetFootstepsAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(footStepsClip);
        }        
    }
    bool isMoving()
    {
        return Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;
    }
}
