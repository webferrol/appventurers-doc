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
        Pause();
        isPaused = !isPaused;

    }

    void UnPause ()
    {
        if (!audioSource.isPlaying) audioSource.UnPause();
        animator.speed = speedInitialValue;
    }

    void Pause()
    {
        if (!audioSource.isPlaying) audioSource.UnPause();
        animator.speed = speedInitialValue;
    }

    // Update is called once per frame     
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Reanudar la reproducción del personaje
            if (isPaused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }

            isPaused = !isPaused;

        }

    }


}
