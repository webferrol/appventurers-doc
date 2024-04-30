using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public bool isPaused = true;
    // Source https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
    
    // Use this for initialization
    void Start()
    {
        
    } 

    // Update is called once per frame     
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Reanudar la reproducción del personaje
            if (isPaused) 
            {
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
            else
            {
                Time.timeScale = 0f;
                AudioListener.pause = true;
            }

            isPaused = !isPaused;

        }

    }


}