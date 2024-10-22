using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class GameOver : MonoBehaviour
{
    [SerializeField] Canvas gameOverScreen;

    void Start()
    {
        gameOverScreen.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverScreen.enabled = true;
        Time.timeScale = 0; //Stops time in game.

        FindObjectOfType<PlayerMovement>().enabled = false;

        Cursor.lockState = CursorLockMode.None; //Unlocks cursor from center of screen.
        Cursor.visible = true; //Makes cursor visible to player.
    }
}
