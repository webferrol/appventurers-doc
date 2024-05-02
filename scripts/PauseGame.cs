using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = true;
    // Source https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/

    // Use this for initialization
    void Start()
    {
        isPaused = true;
        PauseGame();
    }

    void PauseGame()
    {
        
            AudioListener.pause = true;
            Time.timeScale = 0f;
        
    }

    void ResumeGame()
    {
        
            AudioListener.pause = false;
            Time.timeScale = 1;
        
    }

    // Update is called once per frame     
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Reanudar la reproducción del personaje
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

            isPaused = !isPaused;

        }

    }


}
