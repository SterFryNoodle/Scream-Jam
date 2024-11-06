using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBehavior : MonoBehaviour
{    
    [SerializeField] float flashlightFlickerMin = 0f;
    [SerializeField] float flashlightFlickerMax = 2.5f;
    [SerializeField] float flickerSpeed = 6f;

    Light flashlight;
     void Start()
    {
        flashlight = GetComponent<Light>();
    }    

    public void FlickerPlayerLights()
    {
        float time = Mathf.PingPong(Time.time * flickerSpeed, 1.0f);
        flashlight.intensity = Mathf.Lerp(flashlightFlickerMin, flashlightFlickerMax, time);
    }
}
