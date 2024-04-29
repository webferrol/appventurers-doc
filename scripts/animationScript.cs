// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;


public class CastelaoScript : MonoBehaviour
{
    // interfaces
    private AudioSource audioSource;
    private Animator animator;


    // primitivos
    public bool isPaused = true;
    public float velocidadPrevia;

    // Use this for initialization
    void Start()
    {

       audioSource = GetComponent<AudioSource>();
       animator = GetComponent<Animator>();
        velocidadPrevia = animator.speed;
        //  originalRot = transform.localRotation;

    }

    // public void DetenerReproduccion()
    // {
    //     // Detener la animación
    //     animator.speed = 0f;
    // }


  

    // Update is called once per frame     
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Reanudar la reproducción del personaje
            if (isPaused) 
            {
                if (!audioSource.isPlaying) audioSource.UnPause();
                animator.speed = velocidadPrevia;
            }
            else
            {
                if (audioSource.isPlaying) audioSource.Pause();
                animator.speed = 0f;
            }

            isPaused = !isPaused;

        }

    }


}