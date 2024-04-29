using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private AudioSource audioSource;
    private Animator animator;
    public bool isPaused = true;
    public float speedInitialValue;

    // Use this for initialization
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
       animator = GetComponent<Animator>();
        speedInitialValue = animator.speed;
        //originalRot = transform.localRotation;

    } 

    // Update is called once per frame     
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Reanudar la reproducción del personaje
            if (isPaused) 
            {
                if (!audioSource.isPlaying) audioSource.UnPause();
                animator.speed = speedInitialValue;
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