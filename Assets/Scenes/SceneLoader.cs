using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked; //Re-locks cursor from center of screen.
        Cursor.visible = false; //Hides cursor from screen.
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Game has closed.");
    }
}
