using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class ShowEndScreen : MonoBehaviour
{
    [SerializeField] Canvas endOfGameScreen;

    void Start()
    {
        endOfGameScreen.enabled = false;
    }    

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Entered exit collider");
        endOfGameScreen.enabled = true;
        Time.timeScale = 0; //Stops time in game.

        FindObjectOfType<PlayerMovement>().enabled = false;

        Cursor.lockState = CursorLockMode.None; //Unlocks cursor from center of screen.
        Cursor.visible = true; //Makes cursor visible to player.  
    }    
}
